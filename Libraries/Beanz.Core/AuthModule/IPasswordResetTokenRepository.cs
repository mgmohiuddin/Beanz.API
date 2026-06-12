using Beanz.DTOs.Auth;
using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IPasswordResetTokenRepository
    {

        Task<ForgetPasswordRequestResponseDTO> ForgetPasswordRequestAsync(string email, int languageID = 1);
        Task<bool> SavePasswordResetTokenAsync(SavePasswordResetTokenDTO dto);
        Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordRequestDTO dto);
 


        //Task AddAsync(PasswordResetToken token, CancellationToken ct = default);
        //Task<PasswordResetToken?> GetActiveByHashAsync(int userId, string tokenHash, CancellationToken ct = default);
        //Task MarkUsedAsync(PasswordResetToken token, CancellationToken ct = default);
        //Task InvalidateAllForUserAsync(int userId, CancellationToken ct = default);
        //Task<int> SaveChangesAsync(CancellationToken ct = default);


    }
}
