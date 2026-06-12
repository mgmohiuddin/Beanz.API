using Beanz.Core.AuthModule;
using Beanz.Models.AuthModule;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Data.Services.AuthModule
{
    public class ExternalLoginRepository : IExternalLoginRepository
    {
        private readonly string _cs;
        public ExternalLoginRepository(IConfiguration cfg)
            => _cs = cfg.GetConnectionString("SqlConnectionString")!;

        public async Task<(User user, bool isNew)> UpsertExternalUserAsync(
            string provider, string providerUserId,
            string? email, string? displayName, string? pictureUrl)
        {
            using var c = new SqlConnection(_cs);
            await c.OpenAsync();
            using var tx = c.BeginTransaction();

            // 1) Already linked? Return the user.
            const string findByLink = @"
            SELECT u.*
            FROM   auth.Users u
            JOIN   auth.ExternalLogins e ON e.UserID = u.UserID and e.email=u.EmailAddress
            WHERE  e.Provider = @provider AND e.ProviderUserId = @providerUserId and e.email=@email
              AND  u.IsDeleted = 0;";
            var linked = await c.QuerySingleOrDefaultAsync<User>(findByLink,
                new { provider, providerUserId ,email}, tx);

            if (linked is not null)
            {
                await c.ExecuteAsync(@"UPDATE auth.ExternalLogins
                                   SET ModifiedDate = SYSUTCDATETIME(),
                                       Email        = COALESCE(@email,       Email),
                                       DisplayName  = COALESCE(@displayName, DisplayName),
                                       PictureUrl   = COALESCE(@pictureUrl,  PictureUrl)
                                   WHERE Provider = @provider AND ProviderUserId = @providerUserId
                                        AND Email = @email    ;",
                    new { provider, providerUserId, email, displayName, pictureUrl }, tx);
                tx.Commit();
                return (linked, false);
            }

            // 2) Not linked — try to find an existing local user by email and link it.
            User? user = null;
            if (!string.IsNullOrWhiteSpace(email))
            {
                user = await c.QuerySingleOrDefaultAsync<User>(
                    "SELECT TOP 1 * FROM auth.Users WHERE EmailAddress = @email AND IsDeleted = 0;",
                    new { email }, tx);
            }

            // 3) Still no user — create a brand new external-only user (no password).
            bool isNew = false;
            if (user is null)
            {
                const string insertUser = @"
                INSERT INTO auth.Users
                    (UserName, FullName, EmailAddress, ProfilePictureUrl,
                     EmailVerified, IsActive, IsDeleted,
                     PasswordHash, PasswordSalt, CreatedDate)
                OUTPUT INSERTED.*
                VALUES
                    (@UserName, @FullName, @Email, @Picture,
                     1, 1, 0,
                     NULL, NULL, SYSUTCDATETIME());";
                var userName = (email ?? $"{provider.ToLower()}_{providerUserId}").Split('@')[0];
                user = await c.QuerySingleAsync<User>(insertUser, new
                {
                    UserName = userName,
                    FullName = displayName ?? userName,
                    Email = email,
                    Picture = pictureUrl
                }, tx);
                isNew = true;

                // Assign default 'User' role
                await c.ExecuteAsync(@"
                INSERT INTO auth.UserRoles (UserID, RoleID)
                SELECT @uid, RoleID FROM auth.Roles WHERE RoleName = 'User';",
                    new { uid = user.UserID }, tx);
            }

            // 4) Create the link row
            await c.ExecuteAsync(@"
            INSERT INTO auth.ExternalLogins
                (UserID, Provider, ProviderUserId, Email, DisplayName, PictureUrl,
                 CreatedDate, ModifiedDate)
            VALUES
                (@uid, @provider, @providerUserId, @email, @displayName, @pictureUrl,
                 SYSUTCDATETIME(), SYSUTCDATETIME());",
                new { uid = user.UserID, provider, providerUserId, email, displayName, pictureUrl }, tx);

            tx.Commit();
            return (user, isNew);
        }

        public async Task<IEnumerable<ExternalLogin>> GetLinksByUserAsync(long userId)
        {
            using var c = new SqlConnection(_cs);
            return await c.QueryAsync<ExternalLogin>(
                "SELECT * FROM auth.ExternalLogins WHERE UserID = @userId ORDER BY CreatedAtUtc DESC;",
                new { userId });
        }

        public async Task<bool> UnlinkAsync(long userId, string provider)
        {
            using var c = new SqlConnection(_cs);
            var rows = await c.ExecuteAsync(
                "DELETE FROM auth.ExternalLogins WHERE UserID = @userId AND Provider = @provider;",
                new { userId, provider });
            return rows > 0;
        }
    }
}
