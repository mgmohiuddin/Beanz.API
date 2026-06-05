using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IUserTokenRepository
    {
        Task<long> InsertAsync(UserToken token);
        Task<UserToken?> GetByJwtIdAsync(string jwtId);
        Task<List<UserToken>> GetByJwtByUserIDAsync(int? userID);
        
        Task<UserToken?> GetByRefreshTokenAsync(string refreshToken);
        Task RevokeAsync(string jwtId, string reason);
        Task RevokeAllForUserAsync(int? userId, string reason);
        Task<bool> IsBlacklistedAsync(string jwtId);
    }
}
