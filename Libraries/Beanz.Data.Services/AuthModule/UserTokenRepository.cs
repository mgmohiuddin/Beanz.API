using Beanz.Core.AuthModule;
using Beanz.Models.AuthModule;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Beanz.Data.Services.AuthModule
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly string _connectionString;
        public UserTokenRepository(IConfiguration config)
            => _connectionString = config.GetConnectionString("SqlConnectionString")!;

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<long> InsertAsync(UserToken token)
        {
            using var conn = Connection;
            const string sql = @"
            INSERT INTO auth.UserTokens
                (UserID, JWTID, AccessToken, RefreshToken, IssueDate, ExpireDate,
                 IsRevoked, IsBlacklisted, DeviceInfo, IPAddress)
            VALUES
                (@UserID, @JWTID, @AccessToken, @RefreshToken, @IssueDate, @ExpireDate,
                 0, 0, @DeviceInfo, @IPAddress);
            SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
            return await conn.ExecuteScalarAsync<long>(sql, token);
        }

        public async Task<UserToken?> GetByJwtIdAsync(string jwtId)
        {

            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<UserToken>(
                "SELECT TOP 1 * FROM auth.UserTokens WHERE JWTID = @jwtId;", new { jwtId });
        }
        public async Task<List<UserToken>> GetByJwtByUserIDAsync(int? userId)
        {
            try
            {
                using var conn = Connection;
                var userTokens = await conn.QueryAsync<UserToken>(
                    "SELECT * FROM auth.UserTokens WHERE UserID = @UserID AND ExpireDate > SYSUTCDATETIME()  AND (IsRevoked = 0 OR IsRevoked IS NULL);",
                    new { UserID = userId },
                    commandType: CommandType.Text);
                return userTokens.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public async Task<List<UserToken>> GetByJwtByUserIDAsync(int userId)
        //{
        //    try
        //    {
        //        using var conn = Connection;
        //        SqlParameter[] parameters =
        //        {
        //            new SqlParameter("@UserID", SqlDbType.Int) { Value = userId }
        //        };
        //        var userTokens=await conn.QueryAsync<List<UserToken>>("SELECT * FROM auth.UserTokens WHERE UserID = @UserID;", parameters, commandType: CommandType.Text);
        //        return userTokens
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        //public async Task<UserToken?> GetByJwtByUserIDAsync(int userID)
        //{
        //    using var conn = Connection;
        //    return await conn.QueryFirstOrDefaultAsync<UserToken>(
        //        "SELECT * FROM auth.UserTokens WHERE UserID = @userID;", new { userID });
        //}
        public async Task<UserToken?> GetByRefreshTokenAsync(string refreshToken)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<UserToken>(
                "SELECT TOP 1 * FROM auth.UserTokens WHERE RefreshToken = @refreshToken;",
                new { refreshToken });
        }

        public async Task RevokeAsync(string jwtId, string reason)
        {
            using var conn = Connection;
            await conn.ExecuteAsync(@"
            UPDATE auth.UserTokens
            SET IsRevoked = 1, IsBlacklisted = 1, RevokedDate = SYSUTCDATETIME(), RevokedReason = @reason
            WHERE JWTID = @jwtId;", new { jwtId, reason });
        }

        public async Task RevokeAllForUserAsync(int? userId, string reason)
        {
            using var conn = Connection;
            await conn.ExecuteAsync(@"
            UPDATE auth.UserTokens
            SET IsRevoked = 1, IsBlacklisted = 1, RevokedDate = SYSUTCDATETIME(), RevokedReason = @reason
            WHERE UserID = @userId AND IsRevoked = 0;", new { userId, reason });

            await conn.ExecuteAsync(@"
            UPDATE auth.UserSessions SET IsActive = 0, LogoutDate = SYSUTCDATETIME()
            WHERE UserID = @userId AND IsActive = 1;", new { userId });
        }

        public async Task<bool> IsBlacklistedAsync(string jwtId)
        {
            using var conn = Connection;
            return await conn.ExecuteScalarAsync<int>(
                @"SELECT COUNT(1) FROM auth.UserTokens
              WHERE JWTID = @jwtId AND (IsRevoked = 1 OR IsBlacklisted = 1);",
                new { jwtId }) > 0;
        }
    }
}
