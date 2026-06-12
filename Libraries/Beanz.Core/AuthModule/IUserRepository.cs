using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.Models.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IUserRepository
    {
        //Task<User?> GetByIdAsync(long userId);
        Task<EmailVerificationTokenResponseDTO> SaveEmailVerificationTokenAsync(EmailVerificationToken token);
        Task<EmailVerificationToken?> GetEmailVerificationTokenAsync(string token);
        Task MarkEmailVerifiedAsync(int? userId, int? tokenId);

        Task<User?> GetByIdentifierAsync(string identifier);
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByEmailAsync(string _email);
        Task<AuthSignupResponseDTO> ChangePasswordAsync(int? userId, string passwordHash);

        Task<ForgetPasswordRequestResponseDTO> SavePasswordResetTokenAsync(SavePasswordResetTokenDTO token);

        Task<PasswordResetToken?> GetPasswordResetTokenAsync(string token);
    }
}
