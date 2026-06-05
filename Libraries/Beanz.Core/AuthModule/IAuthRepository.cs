using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.DTOs.Common;
using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Beanz.DTOs.Administration.Security;

namespace Beanz.Core.AuthModule
{
    public interface IAuthRepository
    {
        Task<AuthSignupResponseDTO> SignUpAsync(User user);
        //Task<AuthSignInResponseDTO> SignInAsync(AuthSignInDTO signin);
        Task<AuthLoginAttemptResponseDTO> LoginAttemptAsync(LoginAttempt attempt);
        Task UpdateLoginSuccessAsync(int? userId);
        Task UpdateLoginFailureAsync(int? userId, int maxFailedAttempts, int lockoutMinutes);

        Task<IEnumerable<UserCompanies>> GetUserCompanyAsync(User user);
       
        //Task SignUp(SignUpDTO signUpDTO);
        //Task<AuthResponseDTO> SignOutAsync(AuthSignOutDTO common);
        //Task<AuthResponseDTO> ForgetPasswordAsync(AuthForgetPasswordDTO common);
        //Task<AuthResponseDTO> ChangePasswordAsync(AuthChangePasswordDTO common);
        //Task<AuthResponseDTO> ResetPasswordAsync(AuthResetPasswordDTO common);
        //Task<AuthResponseDTO> LockUserAsync(AuthSignInDTO common);
        //Task<AuthResponseDTO> UnLockUserAsync(AuthForgetPasswordDTO common);
        //Task<AuthResponseDTO> LoginAttemptsAsync(AuthSignInDTO common);


    }
}
