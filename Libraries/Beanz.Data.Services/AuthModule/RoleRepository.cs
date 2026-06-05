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

namespace Beanz.Data.Services.AuthModule
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;
        public RoleRepository(IConfiguration config)
            => _connectionString = config.GetConnectionString("SqlConnectionString")!;

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using var conn = Connection;
            return await conn.QueryAsync<Role>(
                "SELECT * FROM auth.Roles WHERE IsActive = 1 ORDER BY RoleName;");
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<Role>(
                "SELECT TOP 1 * FROM auth.Roles WHERE RoleName = @roleName AND IsActive = 1;",
                new { roleName });
        }

        public async Task<IEnumerable<string>> GetUserRoleNamesAsync(int? userId)
        {
            using var conn = Connection;
            return await conn.QueryAsync<string>(@"
            SELECT r.RoleName
            FROM auth.UserRoles ur
            INNER JOIN auth.Roles r ON r.RoleID = ur.RoleID
            WHERE ur.UserID = @userId AND ur.IsActive = 1 AND r.IsActive = 1;",
                new { userId });
        }

        public async Task AssignRoleToUserAsync(int? userId, int? roleId, long? assignedBy = null)
        {
            using var conn = Connection;
            // Idempotent: insert if missing, re-activate if previously removed.
            await conn.ExecuteAsync(@"
            MERGE auth.UserRoles AS tgt
            USING (SELECT @userId AS UserID, @roleId AS RoleID) AS src
              ON  tgt.UserID = src.UserID AND tgt.RoleID = src.RoleID
            WHEN MATCHED THEN
                UPDATE SET IsActive = 1, AssignedDate = SYSUTCDATETIME(), AssignedBy = @assignedBy
            WHEN NOT MATCHED THEN
                INSERT (UserID, RoleID, IsActive, AssignedDate, AssignedBy)
                VALUES (@userId, @roleId, 1, SYSUTCDATETIME(), @assignedBy);",
                new { userId, roleId, assignedBy });
        }

        public async Task AssignRoleToUserByNameAsync(int? userId, string roleName, long? assignedBy = null)
        {
            var role = await GetByNameAsync(roleName)
                ?? throw new System.InvalidOperationException($"Role '{roleName}' does not exist.");
            await AssignRoleToUserAsync(userId, role.RoleID, assignedBy);
        }

        public async Task RemoveRoleFromUserAsync(int? userId, int roleId)
        {
            using var conn = Connection;
            await conn.ExecuteAsync(@"
            UPDATE auth.UserRoles SET IsActive = 0
            WHERE UserID = @userId AND RoleID = @roleId;",
                new { userId, roleId });
        }
    }
}
