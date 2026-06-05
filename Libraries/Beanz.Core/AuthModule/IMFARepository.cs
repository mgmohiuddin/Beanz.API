using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IMFARepository
    {
        Task<UserMFA?> GetUserMFAAsync(int? userId);
        Task<UserMFAResponseDTO> UpsertUserMFAAsync(UserMFA mfa);
        Task<UserMFAResponseDTO> SetMFAEnabledOnUserAsync(UserMFA mfa);
        Task<MFAOTPResponseDTO> UpsertAsync(UserMFA mfa);
        Task<UserMFA?> GetByUserIdAsync(int userId); 
        Task<bool> SetEnabledAsync(int userId, bool enabled);
        Task<bool> DisableAsync(int userId);

        Task<MFAOTPResponseDTO>SaveOtpAsync(MFAOTP otp);
        Task<MFAOTP?> GetOtpByTokenAsync(string mfaToken);
        Task<OTPResponseDTO> MarkOtpUsedAsync(long otpId, int LanguageID);
        Task<OTPResponseDTO> IncrementOtpRetryAsync(long otpId, int LanguageID);
    }
}
