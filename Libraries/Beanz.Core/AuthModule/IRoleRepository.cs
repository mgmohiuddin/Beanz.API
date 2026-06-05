using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByNameAsync(string roleName);

        /// <summary>Active role names for a user (used as JWT 'role' claims).</summary>
        Task<IEnumerable<string>> GetUserRoleNamesAsync(int? userId);

        Task AssignRoleToUserAsync(int? userId, int? roleId, long? assignedBy = null);
        Task AssignRoleToUserByNameAsync(int? userId, string roleName, long? assignedBy = null);
        Task RemoveRoleFromUserAsync(int? userId, int roleId);
    }
}
