using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Beanz.Core.AuthModule;
using Beanz.Data.Services.AuthModule;
using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.RequestResponse.Request;
using Beanz.Models.AuthModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Beanz.API.Services
{
    public class SignUpServiceResult
    {
        public bool Success { get; set; }
        public int? UserID { get; set; }
        public string Message { get; set; } = "";
    }
    public interface IAuthService
    {
        Task<SignUpServiceResult> SignUpAsync(AuthSignupRequestDTO dto, string? ipAddress = null);
        //Task<ForgetPasswordRequestResponseDTO> ForgetPasswordRequestAsync(string email, int langId);
    }
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasherService _hasher;
        private readonly IAuthRepository _authRepository;
        private readonly IRoleRepository _roleRepo;
        private readonly IUserRepository _userRepo;
        private readonly IEmailService _email;
        private readonly AuthSettings _settings;
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
        public AuthService(
       IPasswordHasherService hasher,
       IAuthRepository authRepository,
       IRoleRepository roleRepo,
       IUserRepository userRepo,
       IEmailService email,
       IPasswordResetTokenRepository passwordResetTokenRepository,
       IOptions<AuthSettings> options)
        {
            _hasher = hasher;
            _authRepository = authRepository;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
            _email = email;
            _settings = options.Value;
            _passwordResetTokenRepository= passwordResetTokenRepository;
        }
        public async Task<SignUpServiceResult> SignUpAsync(
        AuthSignupRequestDTO authSingupDTO,
        string? ipAddress = null)
        {
            var hashedPassword = _hasher.Hash(
                authSingupDTO.UserName,
                authSingupDTO.Password);

            var userModel = new User
            {
                EmailAddress = authSingupDTO.EmailAddress,
                UserName = authSingupDTO.UserName,
                PasswordHash = hashedPassword,
                FullName = authSingupDTO.FullName,
                MobileNumber = authSingupDTO.MobileNumber,
                CountryCode = authSingupDTO.CountryCode,
                ProfilePictureUrl = authSingupDTO.ProfilePictureUrl,
                AvatarUrl = authSingupDTO.AvatarUrl,
                PreferredLanguage = authSingupDTO.LanguageID,
                TimeZone = "UTC"
            };

            var data = await _authRepository.SignUpAsync(userModel);

            if (!data.Success)
            {
                return new SignUpServiceResult
                {
                    Success = false,
                    Message = data.Message,
                    UserID = 0
                };
            }

            await _roleRepo.AssignRoleToUserByNameAsync(data.UserID, "User");

            var token = Helpers.TokenGenerator.CreateSecureToken();

            var emailVerificationToken = new EmailVerificationToken
            {
                UserID = data.UserID,
                Token = token,
                EmailAddress = authSingupDTO.EmailAddress,
                ExpireDate = DateTime.UtcNow.AddHours(
                    _settings.EmailVerificationTokenExpiryHours),
                IPAddress = ipAddress,
                LanguageID = authSingupDTO.LanguageID
            };

            var dataEmail =
                await _userRepo.SaveEmailVerificationTokenAsync(emailVerificationToken);

            if (!dataEmail.Success)
            {
                return new SignUpServiceResult
                {
                    Success = false,
                    Message = dataEmail.Message,
                    UserID = data.UserID
                };
            }

            var link =
                $"{_settings.WebAppBaseUrl}/verify-email?token={Uri.EscapeDataString(token)}";

            await _email.SendEmailVerificationAsync(
                authSingupDTO.EmailAddress,
                authSingupDTO.FullName,
                link);

            return new SignUpServiceResult
            {
                Success = true,
                UserID = data.UserID,
                Message = data.Message
            };
        }


       

    }


}
