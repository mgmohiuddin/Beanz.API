using Beanz.Core.AuthModule;
using Beanz.Core.AuthModule.AuthDatabaseEnsure;
using Beanz.Data.Services;
using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.EmailDTOs;
using Beanz.DTOs.AuthModule.ExternalDTOs;
using Beanz.DTOs.AuthModule.MFADTOs;
using Beanz.DTOs.AuthModule.RequestResponse;
using Beanz.DTOs.AuthModule.RequestResponse.Request;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.DTOs.AuthModule.TotpDTOs;
using Beanz.DTOs.AuthModule.UserInfoDTOs;
  
//using Beanz.DTOs.Administration.Security.StoreProcedureDTO;
using Beanz.DTOs.Common;
using Beanz.Models.AuthModule;
using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Beanz.API.Models;
using Beanz.API.Services;
using Beanz.API.Services.ExternalServices;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Apis.Auth;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
//using Beanz.Core.Administration.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Beanz.API.Controllers.AuthModule
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        //private readonly ICompanyUserRepository _companyUserRepository;
        ////private static List<User> users = new List<User>(); // In-memory storage
        //private static Dictionary<string, UserLoginDTO> users = new(); // In-memory store for demo
        public static HashSet<string> _blacklistedTokens = new();
        private readonly IConfiguration _config;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepo;
        private readonly AuthSettings _settings;
        private readonly IMFARepository _mfaRepo;
        private readonly IPasswordHasherService _hasher;
        private readonly IOTPService _otp;
        private readonly IEmailService _email;
        private readonly ISmsService _sms;
        private readonly IUserTokenRepository _tokenRepo;
        private readonly IJWTService _jwt;
        private readonly IRoleRepository _roleRepo;

        private readonly IExternalLoginRepository _ext;
        private readonly IGoogleTokenVerifier _google;
        private readonly IMicrosoftTokenVerifier _microsoft;
        private readonly IFacebookTokenVerifier _facebook;
        private readonly IAppleTokenVerifier _apple;
        private readonly IGitHubTokenVerifier _github;
        private readonly ITwitterTokenVerifier _twitter;
        private readonly ILinkedInTokenVerifier _linkedin;
        private readonly IAuthEnsureRepository _authEnsureRepository;
        private readonly ITotpService _totp;


        public AuthController(IAuthRepository authRepository, IConfiguration config, IUserRepository userRepo,
             IOptions<AuthSettings> settings, IPasswordHasherService hasher
            , IMFARepository mfaRepo
            , IUserTokenRepository tokenRepo
            , IJWTService jwt
            , IEmailService Iemail
            , IRoleRepository roleRepo
            , IGoogleTokenVerifier google
            , IExternalLoginRepository ext
            , IMicrosoftTokenVerifier microsoftTokenVerifier
            , IAuthEnsureRepository authEnsureRepository
            ,IOTPService oTPService
            , ITotpService totp
            )
        {
            _authRepository = authRepository;
            _userRepo = userRepo;
            _settings = settings.Value;
            _hasher = hasher;
            _mfaRepo = mfaRepo;
            _tokenRepo = tokenRepo;
            _roleRepo = roleRepo;
            // _companyUserRepository = CompanyUserRepository;
            _config = config;
            _jwt = jwt;
            _email = Iemail;
            _google = google;
            _ext = ext;
            _microsoft = microsoftTokenVerifier;

            _authEnsureRepository = authEnsureRepository;
            _otp = oTPService;
            _totp = totp;
        }
        // ✅ SIGN UP
        [HttpPost("signupOLD")]
        public async Task<IActionResult> SignUpOLD([FromBody] AuthSignupRequestDTO authSingupDTO)
        {

            try
            {


                //if (!ModelState.IsValid)
                //    return BadRequest(ResponseDTO<object>.Fail("Invalid input", "VALIDATION", 400));


                // var hashedPassword0 = BCrypt.Net.BCrypt.HashPassword(authSingupDTO.Password); 
                //var hashedPassword = EncodePassword(authSingupDTO.Password, authSingupDTO.UserName);
                var hashedPassword = _hasher.Hash(authSingupDTO.UserName, authSingupDTO.Password);

                AuthSignupResponseDTO data = new AuthSignupResponseDTO();


                User userModel = new User();
                userModel.EmailAddress = authSingupDTO.EmailAddress;
                userModel.UserName = authSingupDTO.UserName;
                userModel.PasswordHash = hashedPassword;
                userModel.FullName = authSingupDTO.FullName;
                userModel.MobileNumber = authSingupDTO.MobileNumber;
                userModel.CountryCode = authSingupDTO.CountryCode;
                userModel.ProfilePictureUrl = authSingupDTO.ProfilePictureUrl;
                userModel.AvatarUrl = authSingupDTO.AvatarUrl;
                userModel.PreferredLanguage = authSingupDTO.LanguageID;
                userModel.TimeZone = "UTC";


                data = await _authRepository.SignUpAsync(userModel);

                if (data.Success == false &&
                     !string.IsNullOrEmpty(data.Message) &&
                     data.Message.IndexOf("Invalid object name", StringComparison.OrdinalIgnoreCase) >= 0 &&
                     data.Message.IndexOf("auth.", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var ensureData = await _authEnsureRepository.EnsureUsersTableAsync();

                    if (ensureData.Success == false)
                        return BadRequest(ResponseObjectDTO<object>.Fail(
                            "Auth schema setup failed: " + ensureData.Message, "", 500));

                    // retry signup after schema is ready
                    data = await _authRepository.SignUpAsync(userModel);
                }

                if (data.Success == false)
                {
                    return BadRequest(ResponseObjectDTO<object>.Fail(data.Message, "Fail", 400));
                }
                else
                {
                    // Assign default 'User' role to every new signup
                    await _roleRepo.AssignRoleToUserByNameAsync(data.UserID, "User");

                    var token = Helpers.TokenGenerator.CreateSecureToken();


                    EmailVerificationToken emailVerificationToken = new EmailVerificationToken();
                    emailVerificationToken.UserID = data.UserID;
                    emailVerificationToken.Token = token;
                    emailVerificationToken.EmailAddress = authSingupDTO.EmailAddress;
                    emailVerificationToken.ExpireDate = DateTime.UtcNow.AddHours(_settings.EmailVerificationTokenExpiryHours);
                    emailVerificationToken.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    emailVerificationToken.LanguageID = authSingupDTO.LanguageID;

                    var dataEmail = await _userRepo.SaveEmailVerificationTokenAsync(emailVerificationToken);

                    if (dataEmail.Success == false)
                    {

                        return BadRequest(ResponseObjectDTO<object>.Fail(dataEmail.Message, "Fail", 400));
                    }
                    else
                    {
                        var link = $"{_settings.WebAppBaseUrl}/verify-email?token={Uri.EscapeDataString(token)}";
                        await _email.SendEmailVerificationAsync(authSingupDTO.EmailAddress, authSingupDTO.FullName, link);
                        return Ok(ResponseObjectDTO<object>.Ok(new { data.UserID }, data.Message));
                    }

                }

            }
            catch (Exception ex)
            {


                throw;
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] AuthSignupRequestDTO authSingupDTO)
        {
            try
            {
                return await RunSignUpFlowAsync(authSingupDTO);
            }
            catch (Exception ex)  
            {
                // Self-heal: build all auth tables, then retry once
                if (!HasMissingAuthObject(ex))
                    throw;

                // Schema not initialized — ensure all auth tables, then retry once.
                var ensureResult = await EnsureAllAuthTablesAsync();
                if (!ensureResult.Success)
                {
                    //await RollbackAuthSchemaAsync();
                    return StatusCode(500, ResponseObjectDTO<object>.Fail(
                        "Failed to initialize auth schema: " + ensureResult.Message,"FAIL",500));
                }

                try
                {
                    return await RunSignUpFlowAsync(authSingupDTO);
                }
                catch (Exception retryEx)
                {
                   // await RollbackAuthSchemaAsync();
                    return StatusCode(500, ResponseObjectDTO<object>.Fail(
                        "SignUp failed after schema init: " + retryEx.Message,"FAIL",500));
                }
            }



        }
        private static bool HasMissingAuthObject(Exception? ex)
        {
            while (ex != null)
            {
                if (IsMissingAuthObject(ex.Message))
                    return true;
                ex = ex.InnerException;
            }
            return false;
        }
        private static bool IsMissingAuthObject(string message)
        {
            if (string.IsNullOrEmpty(message)) return false;
            return message.Contains("Invalid object name", StringComparison.OrdinalIgnoreCase)
                && message.Contains("auth.", StringComparison.OrdinalIgnoreCase);
        }

        private async Task<IActionResult> RunSignUpFlowAsync(AuthSignupRequestDTO authSingupDTO)
        {
            try
            {
                var hashedPassword = _hasher.Hash(authSingupDTO.UserName, authSingupDTO.Password);


                User userModel = new User();
                userModel.EmailAddress = authSingupDTO.EmailAddress;
                userModel.UserName = authSingupDTO.UserName;
                userModel.PasswordHash = hashedPassword;
                userModel.FullName = authSingupDTO.FullName;
                userModel.MobileNumber = authSingupDTO.MobileNumber;
                userModel.CountryCode = authSingupDTO.CountryCode;
                userModel.ProfilePictureUrl = authSingupDTO.ProfilePictureUrl;
                userModel.AvatarUrl = authSingupDTO.AvatarUrl;
                userModel.PreferredLanguage = authSingupDTO.LanguageID;
                userModel.TimeZone = "UTC";

                var data = await _authRepository.SignUpAsync(userModel);
                if (!data.Success)
                    return BadRequest(ResponseObjectDTO<object>.Fail(data.Message, "Fail", 400));

                // Assign default "User" role
                await _roleRepo.AssignRoleToUserByNameAsync(data.UserID, "User");

                // Create + persist email verification token
                var token = Helpers.TokenGenerator.CreateSecureToken();


                EmailVerificationToken emailVerificationToken = new EmailVerificationToken();
                emailVerificationToken.UserID = data.UserID;
                emailVerificationToken.Token = token;
                emailVerificationToken.EmailAddress = authSingupDTO.EmailAddress;
                emailVerificationToken.ExpireDate = DateTime.UtcNow.AddHours(_settings.EmailVerificationTokenExpiryHours);
                emailVerificationToken.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                emailVerificationToken.LanguageID = authSingupDTO.LanguageID;

                var dataEmail = await _userRepo.SaveEmailVerificationTokenAsync(emailVerificationToken);

                if (dataEmail.Success == false)
                {

                    return BadRequest(ResponseObjectDTO<object>.Fail(dataEmail.Message, "Fail", 400));
                }
                else
                {
                    var link = $"{_settings.WebAppBaseUrl}/verify-email?token={Uri.EscapeDataString(token)}";
                    await _email.SendEmailVerificationAsync(authSingupDTO.EmailAddress, authSingupDTO.FullName, link);
                    return Ok(ResponseObjectDTO<object>.Ok(new { data.UserID }, data.Message));
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private async Task<GeneralResponseDTO> EnsureAllAuthTablesAsync()
        {
            // ⬇️ HERE — local variable inside the method
            var steps = new (string Name, Func<Task<GeneralResponseDTO>> Run)[]
            {
                ("Users",                   _authEnsureRepository.EnsureUsersTableAsync),
                ("Roles",                   _authEnsureRepository.EnsureRolesTableAsync),
                ("UserRoles",               _authEnsureRepository.EnsureUserRolesTableAsync),
                ("Sessions",                _authEnsureRepository.EnsureUserSessionsTableAsync),
                ("UserTokens",              _authEnsureRepository.EnsureUserTokensTableAsync),
                ("EmailVerificationTokens", _authEnsureRepository.EnsureEmailVerificationTokensTableAsync),
                ("ExternalLogins",          _authEnsureRepository.EnsureExternalLoginsTableAsync),
                ("UserMFA",                 _authEnsureRepository.EnsureUserMFATableAsync),
                ("MFAOTPs",                 _authEnsureRepository.EnsureMFAOTPsTableAsync),
                ("Companies",               _authEnsureRepository.EnsureCompaniesTableAsync),
                ("UserCompanies",               _authEnsureRepository.EnsureUserCompaniesTableAsync),
                
            };

            foreach (var step in steps)
            {
                var result = await step.Run();
                if (!result.Success)
                {
                    return new GeneralResponseDTO
                    {
                        Success = false,
                        Message = $"Ensure {step.Name} failed: {result.Message}"
                    };
                }
            }

            return new GeneralResponseDTO
            {
                Success = true,
                Message = "All auth tables ensured."
            };
        }






        // -------- VERIFY EMAIL --------
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDTO token)
        {
            var record = await _userRepo.GetEmailVerificationTokenAsync(token.Token);
            if (record is null)
                return BadRequest(ResponseObjectDTO<object>.Fail("Invalid verification token.", "TOKEN_INVALID", 400));
            if (record.IsUsed)
                return BadRequest(ResponseObjectDTO<object>.Fail("Verification link already used.", "TOKEN_USED", 400));
            if (record.ExpireDate < DateTime.UtcNow)
                return BadRequest(ResponseObjectDTO<object>.Fail("Verification link has expired.", "TOKEN_EXPIRED", 400));

            await _userRepo.MarkEmailVerifiedAsync(record.UserID, record.TokenID);
            return Ok(ResponseObjectDTO<object>.Ok(new { record.UserID }, "Email verified successfully."));
        }

        // -------- SIGN IN --------
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] AuthSignInRequestDTO dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var ua = Request.Headers.UserAgent.ToString();

            var user = await _userRepo.GetByIdentifierAsync(dto.Username);
            if (user is null)
                return Unauthorized(ResponseObjectDTO<object>.Fail("Invalid credentials.", "INVALID_CREDENTIALS", 401));

            if (user is null || string.IsNullOrEmpty(user.PasswordHash))
            {
                await _authRepository.LoginAttemptAsync(new LoginAttempt
                {
                    UserName = dto.Username,
                    IPAddress = ip,
                    UserAgent = ua,
                    IsSuccess = false,
                    FailureReason = "User not found"
                });
                return Unauthorized(ResponseObjectDTO<object>.Fail("Invalid credentials.", "INVALID_CREDENTIALS", 401));
            }

            if (user.IsLocked && user.LockoutEndDate > DateTime.UtcNow)
                return Unauthorized(ResponseObjectDTO<object>.Fail("Account locked. Try again later.", "ACCOUNT_LOCKED", 423));

            if (!user.IsActive || !user.EmailVerified)
            {
                var token = Helpers.TokenGenerator.CreateSecureToken();
                EmailVerificationToken emailVerificationToken = new EmailVerificationToken();
                emailVerificationToken.UserID = user.UserID;
                emailVerificationToken.Token = token;
                emailVerificationToken.EmailAddress = user.EmailAddress;
                emailVerificationToken.ExpireDate = DateTime.UtcNow.AddHours(_settings.EmailVerificationTokenExpiryHours);
                emailVerificationToken.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                emailVerificationToken.LanguageID = user.LanguageID;

                var dataEmail = await _userRepo.SaveEmailVerificationTokenAsync(emailVerificationToken);

                if (dataEmail.Success == false)
                {
                    return BadRequest(ResponseObjectDTO<object>.Fail(dataEmail.Message, "Fail", 400));
                }
                else
                {
                    return Ok(ResponseObjectDTO<object>.Ok(new { user.UserID }, dataEmail.Message));
                }
                //return Unauthorized(ResponseDTO<object>.Fail("Email not verified.", "EMAIL_NOT_VERIFIED", 403));
            }




            if (!_hasher.Verify(user.UserName, dto.Password, user.PasswordHash))
            {
                //var authLoginAttemptResponse = await _authRepository.UpdateLoginFailureAsync(user.UserID,_settings.MaxFailedLoginAttempts, _settings.LockoutMinutes);
                await _authRepository.UpdateLoginFailureAsync(user.UserID,
               _settings.MaxFailedLoginAttempts, _settings.LockoutMinutes);
                await _authRepository.LoginAttemptAsync(new LoginAttempt
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    IPAddress = ip,
                    UserAgent = ua,
                    IsSuccess = false,
                    FailureReason = "Wrong password",
                    maxFailedAttempts = _settings.MaxFailedLoginAttempts,
                    lockoutMinutes = _settings.LockoutMinutes
                });

                return Unauthorized(ResponseObjectDTO<object>.Fail("Invalid credentials.", "INVALID_CREDENTIALS", 401));

            }
            // ============ MFA GATE ============
            // If the user has MFA enabled, do NOT issue JWT here. Issue a short-lived
            // MFAToken instead; the client must call /api/MFA/verify-otp with the code
            // to receive the real JWT.
            if (user.MFAEnabled)
            {
                var mfaConfig = await _mfaRepo.GetUserMFAAsync(user.UserID);
                if (mfaConfig is null || !mfaConfig.IsActive)
                    return Unauthorized(ResponseObjectDTO<object>.Fail(
                        "MFA is enabled but not configured.", "MFA_NOT_CONFIGURED", 401));

                var mfaToken = Helpers.TokenGenerator.CreateSecureToken();
                string otpCode = null;
                string otpHash = null;

                if (mfaConfig.MFAType == "Email" || mfaConfig.MFAType == "SMS")
                {
                    otpCode = _otp.GenerateNumericOtp(6);
                    otpHash = _hasher.HashRaw(otpCode);
                }

                await _mfaRepo.SaveOtpAsync(new MFAOTP
                {
                    UserID = user.UserID,
                    MFAToken = mfaToken,
                    OTPHash = otpHash,              // null for Authenticator (TOTP)
                    MFAType = mfaConfig.MFAType,
                    ExpireDate = DateTime.UtcNow.AddMinutes(_settings.OtpExpiryMinutes),
                    IPAddress = ip,
                });

                if (mfaConfig.MFAType == "Email")
                    await _email.SendMfaOtpAsync(user.EmailAddress, user.FullName, otpCode);
                else if (mfaConfig.MFAType == "SMS")
                    await _sms.SendOtpAsync(user.CountryCode + user.MobileNumber, otpCode);
                // Authenticator: user reads code from their authenticator app — nothing to send.
                else // Authenticator (TOTP) — user reads code from their app; nothing to send.
                {
                    await _mfaRepo.SaveOtpAsync(new MFAOTP
                    {
                        UserID = user.UserID,
                        MFAToken = mfaToken,
                        OTPHash = "",                       // verified via TOTP secret, not stored hash
                        MFAType = "Authenticator",
                        Purpose = "SignIn",
                        ExpireDate = DateTime.UtcNow.AddMinutes(5),
                        IPAddress = ip,
                    });
                }
                // STOP here — do NOT issue the JWT. Client must call POST /api/MFA/verify-otp.
                return Ok(ResponseObjectDTO<MFAChallengeDTO>.Ok(new MFAChallengeDTO
                {
                    MfaRequired = true,
                    MFAToken = mfaToken,
                    MFAType = mfaConfig.MFAType,
                }, "MFA required. Submit OTP to /api/MFA/verify-otp."));

            }
            // ============ END MFA GATE ============

            // Optional: single login enforcement
            if (!user.AllowMultipleLogin)
            {

                var activeTokens = await _tokenRepo.GetByJwtByUserIDAsync(user.UserID);
                foreach (var t in activeTokens)
                {
                    if (!string.IsNullOrEmpty(t.AccessToken))
                        _blacklistedTokens.Add(t.AccessToken);
                }
                await _tokenRepo.RevokeAllForUserAsync(user.UserID, "AllowMultipleLogin = false");

            }


            await _authRepository.UpdateLoginSuccessAsync(user.UserID);
            await _authRepository.LoginAttemptAsync(new LoginAttempt
            {
                UserID = user.UserID,
                UserName = user.UserName,
                IPAddress = ip,
                UserAgent = ua,
                IsSuccess = true
            });

            // Load roles → embed into JWT claims
            //var roles = await _roleRepo.GetUserRolesAsync(user.UserID);
            var sessionId = Guid.NewGuid();
            var issued = _jwt.IssueAccessToken(user, sessionId);
            var refresh = _jwt.GenerateRefreshToken();
            await _tokenRepo.InsertAsync(new UserToken
            {
                UserID = user.UserID,
                JWTID = issued.JwtId,
                AccessToken = issued.AccessToken,
                RefreshToken = refresh,
                IssueDate = DateTime.UtcNow,
                ExpireDate = issued.ExpiresAt,
                DeviceInfo = dto.DeviceInfo,
                IPAddress = ip,
            });
            var response = new TokenResponseDTO
            {
                AccessToken = issued.AccessToken,
                RefreshToken = refresh,
                ExpiryDate = issued.ExpiresAt,
                User = new UserInfoDTO
                {
                    UserID = user.UserID,
                    UserGuid = user.UserGuid,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    EmailAddress = user.EmailAddress,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    //Roles = roles,
                },
            };
            return Ok(ResponseObjectDTO<TokenResponseDTO>.Ok(response, "Login successful"));

            //// ✅ SIGN IN
            //[HttpPost("signin")]
            //public async Task<IActionResult> SignIn([FromBody] AuthSignInDTO model)
            //{

            //    AuthSignInDTO authSignInDTO = new AuthSignInDTO();
            //    authSignInDTO.Email = model.Email;
            //    authSignInDTO.UserName = model.UserName; 
            //    authSignInDTO.CompanyID = model.CompanyID;
            //    authSignInDTO.Type = model.Type??0;  
            //    authSignInDTO.googleSub = model.googleSub ?? default;
            //    var data = await _authRepository.SignInAsync(authSignInDTO);
            //    if (data.IsValid==true)
            //    {           

            //        if (VerifyPassword(model.Password, data.PasswordHash, data.UserName) || model.Type==2)
            //        { 
            //            if (data.IsActive == false)
            //            {
            //                authSignInDTO.IsFail = false;
            //                authSignInDTO.UserID = data.UserID;
            //                authSignInDTO.CompanyID = model.CompanyID;
            //                var LoginAttempt = await _authRepository.LoginAttemptsAsync(authSignInDTO);
            //                return BadRequest(data.Message);
            //            }
            //            else
            //            {
            //                model.UserID = data.UserID;
            //                model.CompanyID = data.CompanyID;
            //                model.Email = data.Email;
            //                model.UserName = data.UserName;

            //                var token = GenerateJwtToken(model);
            //                var handler = new JwtSecurityTokenHandler();
            //                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            //                var issuedAtClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat)?.Value;
            //                var expirationLocal = jwtToken.ValidTo; // ✅ This will now be in local time

            //                DateTime? issuedAtLocal = null;
            //                if (issuedAtClaim != null && long.TryParse(issuedAtClaim, out long issuedAtUnix))
            //                {
            //                    issuedAtLocal = DateTimeOffset.FromUnixTimeSeconds(issuedAtUnix).LocalDateTime;
            //                }

            //              //  _blacklistedTokens.Add(data.Token);

            //                authSignInDTO.IsFail = false;
            //                authSignInDTO.UserID = data.UserID;
            //                authSignInDTO.CompanyID = model.CompanyID;
            //                authSignInDTO.Token = token;
            //                var LoginAttempt = await _authRepository.LoginAttemptsAsync(authSignInDTO);

            //                AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //                authResponseDTO.IssuedAt = issuedAtLocal?.ToString("yyyy-MM-ddTHH:mm:ss");
            //                authResponseDTO.ExpiresAt = expirationLocal.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss");
            //                authResponseDTO.Token = token;
            //                authResponseDTO.UserID = data.UserID;
            //                authResponseDTO.CompanyID = data.CompanyID;
            //                authResponseDTO.IsValid = data.IsValid;
            //                authResponseDTO.Message = data.Message;

            //                return Ok(new
            //                {
            //                    authResponseDTO.UserID,
            //                    //authResponseDTO.Token,
            //                    authResponseDTO.IsValid,
            //                    authResponseDTO.IsFail,
            //                    authResponseDTO.CompanyID,
            //                    authResponseDTO.IssuedAt,
            //                    authResponseDTO.ExpiresAt,
            //                    JwtToken = authResponseDTO.Token,
            //                });
            //            }
            //        }
            //        else
            //        {
            //            if (model.Password == data.PasswordHash)
            //            {
            //                    var hashedPassword = EncodePassword(model.Password, model.UserName);

            //                    AuthResetPasswordDTO authResetPasswordDTO = new AuthResetPasswordDTO();
            //                    authResetPasswordDTO.Email = model.Email;
            //                    authResetPasswordDTO.UserName = model.UserName;
            //                    authResetPasswordDTO.CompanyID = model.CompanyID;
            //                    authResetPasswordDTO.NewPassword = hashedPassword;
            //                    authResetPasswordDTO.ConfirmPassword = hashedPassword;
            //                    authResetPasswordDTO.UserID=data.UserID;
            //                    var Resetdata = await _authRepository.ResetPasswordAsync(authResetPasswordDTO);

            //            }
            //            authSignInDTO.IsFail = true;
            //            authSignInDTO.UserID = data.UserID;
            //            authSignInDTO.CompanyID = data.CompanyID;
            //            authSignInDTO.Email = model.Email;
            //            authSignInDTO.UserName = model.UserName;
            //            var LoginAttempt = await _authRepository.LoginAttemptsAsync(authSignInDTO);
            //            return Unauthorized("Invalid credentials.");
            //        }
            //    }
            //    else
            //    {
            //        return BadRequest(data.Message);
            //    }
            //}


            //// ✅ SIGN OUT (Handled on the client-side or with token revocation)
            //[Authorize]
            //[HttpPost("signout")]
            //public async Task<IActionResult> SignOut([FromBody]  AuthSignInDTO model)
            //{


            //    if (ValidateTokeUser(model))
            //    {
            //        //string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            //        //var db = _redis.GetDatabase();
            //        //await db.StringSetAsync($"blacklist:{token}", "true", TimeSpan.FromHours(2)); // Expire in 2 hours
            //        string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            //        // Add token to blacklist
            //        _blacklistedTokens.Add(token);
            //        AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //        authResponseDTO.Message = "Signed out successfully. Token blacklisted.";

            //        return Ok(authResponseDTO);
            //    }
            //    else
            //    {
            //        return Unauthorized("Invalid Token");
            //    }

            //}

            //// ✅ Middleware to Check if Token is Blacklisted (Should be added in request pipeline)
            //// ✅ Middleware to Check if Token is Blacklisted
            //private bool IsTokenBlacklisted(string token)
            //{
            //    return _blacklistedTokens.Contains(token);
            //}

            //// ✅ FORGET PASSWORD (Simulated email reset token)
            //[HttpPost("forget-password")]
            //public IActionResult ForgetPassword([FromBody] AuthForgetPasswordDTO model)
            //{
            //    // if (!users.ContainsKey(model.Email)) return BadRequest("User not found.");

            //    //string resetToken = Guid.NewGuid().ToString(); // Simulated token
            //    AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //    authResponseDTO.Message = "reset password link sent to email ";

            //    return Ok(authResponseDTO);
            //    //return Ok(new { Message = "Reset token sent to email (simulated).", ResetToken = resetToken });
            //}


            //// ✅ CHANGE PASSWORD
            //[Authorize]
            //[HttpPost("change-password")]
            //public async Task<IActionResult> ChangePassword([FromBody] AuthChangePasswordDTO model)
            //{


            //    if (model.NewPassword == model.ConfirmPassword)
            //    {
            //        AuthSignInDTO authSignInDTO = new AuthSignInDTO();
            //        authSignInDTO.Email = model.Email;
            //        authSignInDTO.UserName = model.UserName;
            //        authSignInDTO.CompanyID = model.CompanyID;
            //        var data = await _authRepository.SignInAsync(authSignInDTO);

            //        if (data.IsValid == true)
            //        {
            //            if (VerifyPassword(model.OldPassword, data.PasswordHash, model.UserName))
            //            {
            //                if (data.IsActive == false)
            //                {
            //                    return BadRequest(data.Message);
            //                }
            //                else
            //                {
            //                    var hashedOldPassword = EncodePassword(model.OldPassword, model.UserName);
            //                    var hashedNewPassword = EncodePassword(model.NewPassword, model.UserName);
            //                    AuthChangePasswordDTO authChangePassDTO = new AuthChangePasswordDTO();
            //                    authChangePassDTO.Email = data.Email;
            //                    authChangePassDTO.UserName = model.UserName;
            //                    authChangePassDTO.OldPassword = hashedOldPassword;
            //                    authChangePassDTO.NewPassword = hashedNewPassword;
            //                    authChangePassDTO.ConfirmPassword = hashedNewPassword;
            //                    authChangePassDTO.UserID = data.UserID;
            //                    authChangePassDTO.CompanyID = data.CompanyID;

            //                    var ChangePassdata = await _authRepository.ChangePasswordAsync(authChangePassDTO);
            //                    AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //                    authResponseDTO.Message = ChangePassdata.Message;

            //                    return Ok(authResponseDTO);
            //                    //return Ok(new { ChangePassdata.Message });

            //                }
            //            }
            //            else
            //            {
            //                AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //                authResponseDTO.Message = "Old Password is not valid";
            //                authResponseDTO.IsFail = true;
            //                return Ok(authResponseDTO);
            //                //return BadRequest("Old Password is not valid");
            //            }
            //        }
            //        else
            //        {
            //            AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //            authResponseDTO.Message = "User Is not Valid";
            //            authResponseDTO.IsFail = true;
            //            return Ok(authResponseDTO);

            //        }



            //    }
            //    else
            //    {
            //        AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
            //        authResponseDTO.Message = "Password Confirm Password not matched";
            //        return Ok(authResponseDTO);

            //    }
            //    ////DecodeJwtToken();
            //    //var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            //    //UserLoginDTO userLogin = new UserLoginDTO();
            //    //userLogin.UserName = model.UserName;
            //    //userLogin.Email = model.Email;

            //    //if(ValidateTokeUser(userLogin))
            //    //{
            //    //    var handler = new JwtSecurityTokenHandler();
            //    //    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            //    //    if (jsonToken == null)
            //    //    {
            //    //        return Unauthorized("Invalid Token");
            //    //    }

            //    //    var claims = jsonToken.Claims;
            //    //    var userName1 = claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
            //    //    var userEmail1 = claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            //    //    string userEmail = User.FindFirstValue(ClaimTypes.Email);
            //    //    if (userEmail == null || !users.ContainsKey(userEmail))
            //    //        return Unauthorized("User not found.");

            //    //    users[userEmail].PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            //    //    return Ok(new { Message = "Password changed successfully!" });
            //    //}
            //    //{
            //    //    return Unauthorized("Invalid Token");
            //    //}

            //}

            //// 🔑 Helper: Generate JWT Token
            //private string GenerateJwtToken(AuthSignInDTO user)
            //{
            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //    var issuedAt = DateTime.Now;   // Issue time (iat)
            //    var expiration = issuedAt.AddDays(7); // Expiration time (exp)

            //    var claims = new[]
            //    {

            //        //new Claim(ClaimTypes.Email,user.Email ?? string.Empty ),
            //        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString() ),
            //        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            //        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(issuedAt).ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64)
            //        //new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(20))
            //    };

            //    var token = new JwtSecurityToken(
            //        _config["Jwt:Issuer"],
            //        _config["Jwt:Audience"],
            //        claims:claims,
            //        notBefore: issuedAt, // Token is valid from this time
            //        expires: expiration, // Correct expiration time
            //        signingCredentials: credentials
            //    );

            //    return new JwtSecurityTokenHandler().WriteToken(token);
            //}

            //private static DateTime? GetTokenExpiration(string token)
            //{
            //    var handler = new JwtSecurityTokenHandler();
            //    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            //    return jwtToken?.ValidTo; // Returns expiration time in UTC
            //}

            //private bool ValidateTokeUser(AuthSignInDTO user)
            //{
            //    // Get Authorization header
            //    var authHeader = Request.Headers["Authorization"].ToString();
            //    if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            //    {
            //        return false;
            //    }

            //    // Extract the token (remove "Bearer ")
            //    var token = authHeader.Replace("Bearer ", string.Empty);

            //    var handler = new JwtSecurityTokenHandler();
            //    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            //    if (jwtToken == null)
            //    {
            //        return false;
            //    }

            //    // Get expiration time from the token
            //    var expirationTime = jwtToken.ValidTo;
            //    string TokenEmail = User.FindFirstValue(ClaimTypes.Email);
            //    string TokenNameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    string TokenUserName = User.FindFirstValue(ClaimTypes.Name);
            //    if(TokenNameIdentifier==user.UserID.ToString())
            //    {
            //        //if (TokenUserName==user.UserName)
            //        //{
            //            return true;
            //        //}
            //        //else
            //        //{
            //        //    return false;
            //        //}
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}



            //private static void DecodeJwtToken(string token)
            //{
            //    var handler = new JwtSecurityTokenHandler();

            //    // Parse the JWT token
            //    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            //    if (jsonToken == null)
            //    {
            //        Console.WriteLine("Invalid token");
            //        return;
            //    }

            //    // Extract claims (the payload of the JWT token)
            //    foreach (var claim in jsonToken.Claims)
            //    {
            //        Console.WriteLine($"{claim.Type}: {claim.Value}");
            //    }
            //}

        }




        // STEP 1 — Authenticated user clicks "Enable Authenticator"
        // Returns: secret (manual key), otpauth URL, QR PNG (base64)
        [HttpPost("mfa/totp/setup")]
        [Authorize]
        public async Task<IActionResult> Setup()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null) return Unauthorized();

            var secret = _totp.GenerateSecretBase32();
            var otpAuth = _totp.BuildOtpAuthUrl(secret, user.EmailAddress, "MyApp");
            var qrBase64 = _totp.BuildQrPngBase64(otpAuth);

            // Save secret but keep IsEnabled = 0 until the user proves they scanned it.
            await _mfaRepo.UpsertAsync(new UserMFA
            {
                UserID = userId,
                MFAType = "Authenticator",
                SecretKey = secret
            });

            return Ok(new TotpSetupResponseDTO
            {
                SecretBase32 = secret,
                OtpAuthUrl = otpAuth,
                QrCodePngBase64 = qrBase64
            });
        }

        // STEP 2 — User types the first 6-digit code from their app to confirm
        [HttpPost("mfa/totp/enable")]
        [Authorize]
        public async Task<IActionResult> Enable([FromBody] TotpEnableDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var mfa = await _mfaRepo.GetByUserIdAsync(userId);
            if (mfa == null || string.IsNullOrEmpty(mfa.SecretKey))
                return BadRequest(new { message = "Run /setup first." });

            if (!_totp.VerifyCode(mfa.SecretKey, dto.Code))
                return BadRequest(new { message = "Invalid code. Check device time and try again." });

            await _mfaRepo.SetEnabledAsync(userId, true);
            return Ok(new { message = "Authenticator enabled." });
        }

        // STEP 3 — Called during sign-in after password is accepted and user has MFA enabled.
        // The sign-in flow returns an MFA challenge token, then the client posts the 6-digit code here.
        [HttpPost("mfa/totp/verify")]
        [AllowAnonymous] // called between password step and final token issue
        public async Task<IActionResult> Verify([FromBody] TotpVerifyDTO dto)
        {
            var mfa = await _mfaRepo.GetByUserIdAsync(dto.UserID);
            if (mfa == null || !mfa.IsEnabled || string.IsNullOrEmpty(mfa.SecretKey))
                return BadRequest(new { message = "Authenticator MFA not enabled for this user." });

            if (!_totp.VerifyCode(mfa.SecretKey, dto.Code))
                return Unauthorized(new { message = "Invalid or expired code." });

            // Caller (sign-in flow) now issues the final JWT.
            return Ok(new { message = "Verified." });
        }



        // OPTIONAL — Disable Authenticator
        [HttpPost("mfa/totp/disable")]
        [Authorize]
        public async Task<IActionResult> Disable()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _mfaRepo.DisableAsync(userId);
            return Ok(new { message = "Authenticator disabled." });
        }



        [HttpPost("external/google")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInDTO dto)
        {
            var profile = await _google.VerifyAsync(dto.IdToken);
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "Google", profile.Sub, profile.Email, profile.Name, profile.Picture);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Ok(ResponseObjectDTO<object>.Ok((object)new { accessToken = access, refreshToken = refresh, isNew }, "Signed in"));
        }

        [HttpPost("external/microsoft")]
        [AllowAnonymous]
        public async Task<IActionResult> MicrosoftSignIn([FromBody] MicrosoftSignInDTO dto)
        {
            var p = await _microsoft.VerifyAsync(dto.IdToken);
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "Microsoft", p.Sub, p.Email, p.Name, null);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Ok(ResponseObjectDTO<object>.Ok((object)new { accessToken = access, refreshToken = refresh, isNew }, "Signed in"));
        }

        [HttpPost("external/facebook")]
        [AllowAnonymous]
        public async Task<IActionResult> FacebookSignIn([FromBody] FacebookSignInDTO dto)
        {
            var p = await _facebook.VerifyAsync(dto.AccessToken);
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "Facebook", p.Id, p.Email, p.Name, p.Picture?.Data?.Url);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Ok(ResponseObjectDTO<object>.Ok((object)new { accessToken = access, refreshToken = refresh, isNew }, "Signed in"));
        }

        [HttpPost("external/apple/callback")]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AppleCallback([FromForm] AppleSignInDTO dto)
        {
            var p = await _apple.VerifyAsync(dto.IdToken);
            // Parse 'user' JSON ONLY on first login to capture name
            string? displayName = null;
            if (!string.IsNullOrEmpty(dto.UserJson))
            {
                var u = System.Text.Json.JsonDocument.Parse(dto.UserJson).RootElement;
                if (u.TryGetProperty("name", out var n))
                    displayName = $"{n.GetProperty("firstName").GetString()} {n.GetProperty("lastName").GetString()}".Trim();
            }
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "Apple", p.Sub, p.Email, displayName, null);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Redirect($"https://localhost:7064/auth/callback?token={refresh}");
        }

        [HttpGet("external/github/callback")]
        [AllowAnonymous]
        public async Task<IActionResult> GitHubCallback([FromQuery] string code, [FromQuery] string? state)
        {
            var p = await _github.ExchangeAndFetchAsync(code);
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "GitHub", p.Id.ToString(), p.Email, p.Name ?? p.Login, p.Avatar_url);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Redirect($"https://localhost:7064/auth/callback?token={refresh}");
        }

        [HttpPost("external/twitter")]
        [AllowAnonymous]
        public async Task<IActionResult> TwitterSignIn([FromBody] TwitterCallbackDTO dto)
        {
            // Validate state == cached state, fetch codeVerifier from cache by state
            var u = await _twitter.ExchangeAndFetchAsync(dto.Code, dto.CodeVerifier);
            // NOTE: Twitter does NOT return email by default — requires elevated access
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "Twitter", u.Id, email: null, u.Name ?? u.Username, u.Profile_image_url);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Ok(ResponseObjectDTO<object>.Ok((object)new { accessToken = access, refreshToken = refresh, isNew }, "Signed in"));
        }

        [HttpGet("external/linkedin/callback")]
        [AllowAnonymous]
        public async Task<IActionResult> LinkedInCallback([FromQuery] string code, [FromQuery] string? state)
        {
            var p = await _linkedin.ExchangeAndFetchAsync(code);
            var (user, isNew) = await _ext.UpsertExternalUserAsync(
                "LinkedIn", p.Sub, p.Email, p.Name, p.Picture);
            var roles = await _roleRepo.GetUserRoleNamesAsync(user.UserID);
            var access = _jwt.IssueAccessToken(user, Guid.NewGuid(), roles);
            var refresh = _jwt.GenerateRefreshToken();
            return Redirect($"https://localhost:7064/auth/callback?token={refresh}");
        }

        [Authorize]
        [HttpPost("signout")]
        public async Task<IActionResult> SignOut([FromBody] AuthSignOutDTO model)
        {
            if (ValidateTokeUser(model))
            {
                //string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                //var db = _redis.GetDatabase();
                //await db.StringSetAsync($"blacklist:{token}", "true", TimeSpan.FromHours(2)); // Expire in 2 hours
                string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Add token to blacklist
                _blacklistedTokens.Add(token);
                AuthSignInResponseDTO authResponseDTO = new AuthSignInResponseDTO();
                authResponseDTO.Message = "Signed out successfully. Token blacklisted.";

                return Ok(authResponseDTO);
            }
            else
            {
                return Unauthorized("Invalid Token");
            }
            //var jti = User.FindFirstValue("jti") ?? User.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti);
            //if (string.IsNullOrEmpty(jti))
            //    return BadRequest(ResponseDTO<object>.Fail("Token id missing.", "JTI_MISSING", 400));

            //// Read raw bearer token from header and add to in-memory blacklist
            //var authHeader = Request.Headers["Authorization"].ToString();
            //if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            //{
            //    var rawToken = authHeader.Substring("Bearer ".Length).Trim();
            //    if (!string.IsNullOrEmpty(rawToken))
            //        _blacklistedTokens.Add(rawToken);
            //}

            //// Revoke in DB
            //await _tokenRepo.RevokeAsync(jti, "User signed out");

            //return Ok(ResponseDTO<object>.Ok(new { signedOut = true }, "Signed out successfully."));
        }

        private bool ValidateTokeUser(AuthSignOutDTO user)
        {
            // Get Authorization header
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return false;
            }

            // Extract the token (remove "Bearer ")
            var token = authHeader.Replace("Bearer ", string.Empty);

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                return false;
            }

            // Get expiration time from the token
            var expirationTime = jwtToken.ValidTo;
            string TokenEmail = User.FindFirstValue(ClaimTypes.Email);
            string TokenNameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string TokenUserName = User.FindFirstValue(ClaimTypes.Name);
            if (TokenNameIdentifier == user.UserID.ToString())
            {
                //if (TokenUserName==user.UserName)
                //{
                return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            else
            {
                return false;
            }
        }



        [Authorize]
        [HttpPost("select-company")]
        public async Task<IActionResult> SelectCompany([FromBody] AuthSignOutDTO model)
        {
            if (ValidateTokeUser(model))
            {
                User userDTO = new User();
                userDTO.UserID = model.UserID;

                var user = await _authRepository.GetUserCompanyAsync(userDTO);

                ////string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                ////var db = _redis.GetDatabase();
                ////await db.StringSetAsync($"blacklist:{token}", "true", TimeSpan.FromHours(2)); // Expire in 2 hours
                //string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                //// Add token to blacklist
                //_blacklistedTokens.Add(token);
                //AuthSignInResponseDTO authResponseDTO = new AuthSignInResponseDTO();
                //authResponseDTO.Message = "Signed out successfully. Token blacklisted.";

                 return Ok(user);
            }
            else
            {
                return Unauthorized("Invalid Token");
            }

        }

       



        // ============================================================
        // Core signup flow (extracted so we can retry)
        // ============================================================



        // ============================================================
        // Ensure ALL auth tables in dependency order
        // ============================================================


        //    private async Task<GeneralResponseDTO> EnsureAllAuthTablesAsync()
        //    {



        //        foreach (var step in steps)
        //        {
        //            var result = await step.Run();
        //            if (!result.Success)
        //            {
        //                return new GeneralResponseDTO
        //                {
        //                    Success = false,
        //                    Message = $"Ensure {step.Name} failed: {result.Message}"
        //                };
        //            }
        //        }
        //        return new GeneralResponseDTO { Success = true, Message = "All auth tables ensured." };


        //    }

        //}




        //private bool VerifyPassword(string password, string hashedPassword, string UserName)
        //{
        //    try
        //    {
        //        string key = "thisisboom";
        //        string dcodeto = key + UserName + password;
        //        if (password == hashedPassword)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return BCrypt.Net.BCrypt.Verify(dcodeto, hashedPassword);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //    //var hashedPassword1 = BCrypt.Net.BCrypt.HashPassword(dcodeto);

        //}


        //////-----------------------------------google start
        //public class GoogleAuthRequest
        //{
        //    public string Token { get; set; } = "";
        //}

        ////[HttpPost("googleold")]
        ////public async Task<IActionResult> GoogleAuthold([FromBody] GoogleAuthRequest req)
        ////{
        ////    if (string.IsNullOrWhiteSpace(req.Token))
        ////        return BadRequest("Token is required. Please provide a valid Google authentication token or contact your administrator to ensure it has been properly configured.");

        ////    var googleUserInfo = await VerifyGoogleTokenAsync(req.Token);
        ////    if (googleUserInfo == null)
        ////        return Unauthorized("Invalid Google token. Please check with your administrator to confirm whether it has been configured correctly.");


        ////    var googleSub = googleUserInfo.Subject;
        ////    var email = googleUserInfo.Email;
        ////    var name = googleUserInfo.Name;

        ////    var authSignInDTO = new AuthSignInDTO
        ////    {
        ////        Email = email,
        ////        googleSub = googleSub,
        ////        Type = 2
        ////    };

        ////    IActionResult signInResult = await SignIn(authSignInDTO);
        ////    AuthResponseDTO authResponseDTO = new AuthResponseDTO();
        ////    if (signInResult is OkObjectResult ok)
        ////    {
        ////        // Best case: already AuthResponseDTO
        ////        if (ok.Value is AuthResponseDTO dto)
        ////        {
        ////            authResponseDTO = dto;
        ////        }
        ////        else
        ////        {
        ////            // If ok.Value is an anonymous object, convert via JSON (fallback)
        ////            var json = JsonConvert.SerializeObject(ok.Value);
        ////            authResponseDTO = JsonConvert.DeserializeObject<AuthResponseDTO>(json) ?? new AuthResponseDTO();
        ////        }
        ////    }
        ////    else if (signInResult is ObjectResult obj) // BadRequestObjectResult, etc.
        ////    {
        ////        // You can return the actual status code/message from SignIn
        ////        return StatusCode(obj.StatusCode ?? 400, obj.Value);
        ////    }
        ////    else if (signInResult is UnauthorizedResult)
        ////    {
        ////        return Unauthorized();
        ////    }
        ////    else
        ////    {
        ////        return StatusCode(500, "Unexpected SignIn response type");
        ////    }

        ////    if (authResponseDTO.IsValid == true)
        ////    {
        ////        return Ok(new
        ////        {
        ////            authResponseDTO.UserID,
        ////            authResponseDTO.IsValid,
        ////            authResponseDTO.IsFail,
        ////            authResponseDTO.CompanyID,
        ////            authResponseDTO.IssuedAt,
        ////            authResponseDTO.ExpiresAt,
        ////            authResponseDTO.JwtToken,
        ////        });
        ////    }
        ////    else
        ////    {
        ////        var tokenString = "";
        ////        return Ok(new { token = tokenString });
        ////    }
        ////}
        //////AuthSignInDTO authSignInDTO = new AuthSignInDTO();
        //////authSignInDTO.Email = email;
        //////authSignInDTO.googleSub = googleSub;
        //////authSignInDTO.Type = 2;

        //////AuthResponseDTO authResponseDTO = new AuthResponseDTO();
        //////var data = await SignIn(authSignInDTO) as OkObjectResult;
        //////var authResponse = data.Value as AuthResponseDTO;

        //////var json = JsonConvert.SerializeObject(data.Value);
        //////authResponseDTO = JsonConvert.DeserializeObject<AuthResponseDTO>(json);

        //////if (authResponseDTO.IsValid == true)
        //////{ 
        //////    return Ok(new
        //////    {
        //////        authResponseDTO.UserID,
        //////        //authResponseDTO.Token,
        //////        authResponseDTO.IsValid,
        //////        authResponseDTO.IsFail,
        //////        authResponseDTO.CompanyID,
        //////        authResponseDTO.IssuedAt,
        //////        authResponseDTO.ExpiresAt,
        //////         authResponseDTO.JwtToken,
        //////    });
        //////}
        //////else
        //////{
        //////    var tokenString = "";
        //////    return Ok(new { token = tokenString });
        //////}
        //////var tokenString = "";
        //////return Ok(new { token = tokenString });

        //[HttpPost("google")]
        //public async Task<IActionResult> GoogleAuth([FromBody] GoogleAuthRequest req)
        //{
        //    if (string.IsNullOrWhiteSpace(req.Token))
        //        return BadRequest(new { success = false, message = "Token is required. Please provide a valid Google authentication token or contact your administrator to ensure it has been properly configured." });

        //    var googleResult = await VerifyGoogleTokenAsync(req.Token);

        //    if (!googleResult.Success || googleResult.Payload == null)
        //    {
        //        return Unauthorized(new
        //        {
        //            success = false,
        //            message = googleResult.Message,
        //            type = googleResult.Type
        //        });
        //    }
        //    var googleUserInfo = googleResult.Payload;

        //    var googleSub = googleUserInfo.Subject;
        //    var email = googleUserInfo.Email;
        //    var name = googleUserInfo.Name;

        //    var authSignInDTO = new AuthSignInDTO
        //    {
        //        Email = email,
        //        googleSub = googleSub,
        //        Type = 2
        //    }; 

        //    IActionResult signInResult = await SignIn(authSignInDTO);
        //    AuthResponseDTO authResponseDTO = new Beanz.DTOs.Auth.AuthResponseDTO();
        //    if (signInResult is OkObjectResult ok)
        //    {
        //        // Best case: already AuthResponseDTO
        //        if (ok.Value is AuthResponseDTO dto)
        //        {
        //            authResponseDTO = dto;
        //        }
        //        else
        //        {
        //            // If ok.Value is an anonymous object, convert via JSON (fallback)
        //            var json = JsonConvert.SerializeObject(ok.Value);
        //            authResponseDTO = JsonConvert.DeserializeObject<AuthResponseDTO>(json) ?? new Beanz.DTOs.Auth.AuthResponseDTO();
        //        }
        //    }
        //    else if (signInResult is ObjectResult obj) // BadRequestObjectResult, etc.
        //    {
        //        // You can return the actual status code/message from SignIn
        //        return StatusCode(obj.StatusCode ?? 400, obj.Value);
        //    }
        //    else if (signInResult is UnauthorizedResult)
        //    {
        //        return Unauthorized();
        //    }
        //    else
        //    {
        //        return StatusCode(500, "Unexpected SignIn response type");
        //    }

        //    if (authResponseDTO.IsValid == true)
        //    {
        //        return Ok(new
        //        {
        //            authResponseDTO.UserID,
        //            authResponseDTO.IsValid,
        //            authResponseDTO.IsFail,
        //            authResponseDTO.CompanyID,
        //            authResponseDTO.IssuedAt,
        //            authResponseDTO.ExpiresAt,
        //            authResponseDTO.JwtToken,
        //        });
        //    }
        //    else
        //    {
        //        var tokenString = "";
        //        return Ok(new { token = tokenString });
        //    }
        //}

        //private string CreateJwt(string email, string name, string googleSub)
        //{

        //    var issuer = _config["Jwt:Issuer"]!;
        //    var audience = _config["Jwt:Audience"]!;
        //    var keyStr = _config["Jwt:Key"]!;

        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, googleSub),
        //    new Claim(JwtRegisteredClaimNames.Email, email),
        //    new Claim("name", name),
        //    new Claim("provider", "google")
        //};

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var jwt = new JwtSecurityToken(
        //        issuer: issuer,
        //        audience: audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(2),
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(jwt);
        //}

        //private async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleTokenAsyncold(string token)
        //{
        //    try
        //    {
        //        var clientId = _config["Google:ClientId"]; // put Google ClientId here
        //        return await GoogleJsonWebSignature.ValidateAsync(token,
        //            new GoogleJsonWebSignature.ValidationSettings
        //            {
        //                Audience = new[] { clientId }
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public class GoogleTokenResult
        //{
        //    public bool Success { get; set; }
        //    public GoogleJsonWebSignature.Payload? Payload { get; set; }
        //    public string? Message { get; set; }
        //    public string? Type { get; set; }
        //}

        //private async Task<GoogleTokenResult> VerifyGoogleTokenAsyncp(string token)
        //{
        //    var clientId = _config["Google:ClientId"];
        //    var settings = new GoogleJsonWebSignature.ValidationSettings
        //    {
        //        Audience = new[] { clientId }
        //    };

        //    Exception? lastEx = null;

        //    // Retry up to 3 times with 2s delay to absorb small clock skew
        //    for (int attempt = 0; attempt < 3; attempt++)
        //    {
        //        try
        //        {
        //            var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
        //            return new GoogleTokenResult { Success = true, Payload = payload };
        //        }
        //        catch (InvalidJwtException ex) when (ex.Message.Contains("not yet valid", StringComparison.OrdinalIgnoreCase))
        //        {
        //            lastEx = ex;
        //            await Task.Delay(2000); // wait for server clock to catch up
        //        }
        //        catch (Exception ex)
        //        {
        //            return new GoogleTokenResult
        //            {
        //                Success = false,
        //                Message = ex.Message,
        //                Type = ex.GetType().Name
        //            };
        //        }
        //    }

        //    return new GoogleTokenResult
        //    {
        //        Success = false,
        //        Message = lastEx?.Message ?? "Token validation failed",
        //        Type = lastEx?.GetType().Name ?? "InvalidJwtException"
        //    };
        //}


        //private async Task<GoogleTokenResult> VerifyGoogleTokenAsync(string token)
        //{
        //    try
        //    {
        //        var clientId = _config["Google:ClientId"];

        //        var payload = await GoogleJsonWebSignature.ValidateAsync(
        //            token,
        //            new GoogleJsonWebSignature.ValidationSettings
        //            {
        //                Audience = new[] { clientId }
        //            });

        //        return new GoogleTokenResult
        //        {
        //            Success = true,
        //            Payload = payload
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GoogleTokenResult
        //        {
        //            Success = false,
        //            Message = ex.Message,
        //            Type = ex.GetType().Name
        //        };
        //    }
        //}
        //////-----------------------------------google end
        /////
        ///// return BadRequest(new

        ///// 
        ///// 
        ///// 
        //////-----------------------------------google start


        ////public string GenerateGootleJWTToken(ClaimsPrincipal user)
        ////{
        ////    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        ////    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        ////    var token = new JwtSecurityToken(
        ////        _config["Jwt:Issuer"],
        ////        _config["Jwt:Audience"],
        ////        claims: user.Claims,
        ////        expires: DateTime.UtcNow.AddHours(2),
        ////        signingCredentials: credentials
        ////    );

        ////    return new JwtSecurityTokenHandler().WriteToken(token);
        ////}

        ////public class GoogleAuthRequest
        ////{
        ////    public string Token { get; set; }
        ////}

        ////[HttpPost("GoogleSignup")]
        ////public async Task<IActionResult> GoogleSignUp([FromBody] GoogleAuthRequest googleAuthRequest)
        ////{
        ////    var token = googleAuthRequest.Token;
        ////    var googleUserInfo = await VerifyGoogleTokenAsync(token);
        ////    if (googleUserInfo == null)
        ////    {
        ////        return Unauthorized("Invalid Google Token");
        ////    }

        ////    var userId = googleUserInfo.Subject; // Google user ID
        ////    var email = googleUserInfo.Email;

        ////    // You can implement user creation logic here if needed (e.g., save the user info in a database)

        ////    // Create JWT Token
        ////    var claims = new[]
        ////    {
        ////        new Claim(ClaimTypes.Name, email),
        ////        new Claim(ClaimTypes.NameIdentifier, userId),
        ////        new Claim(ClaimTypes.Email, email),
        ////    };

        ////    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
        ////    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        ////    var tokenDescriptor = new JwtSecurityToken(
        ////        issuer: _config["Jwt:Issuer"],
        ////        audience: _config["Jwt:Audience"],
        ////        claims: claims,
        ////        expires: DateTime.UtcNow.AddDays(1),
        ////        signingCredentials: creds);

        ////    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        ////    return Ok(new { Token = tokenString });
        ////}


        ////// POST: api/user/signin
        ////[HttpPost("Googlesignin")]
        ////public async Task<IActionResult> GoogleSignIn([FromBody] GoogleAuthRequest googleAuthRequest)
        ////{
        ////    var token = googleAuthRequest.Token;
        ////    var googleUserInfo = await VerifyGoogleTokenAsync(token);
        ////    if (googleUserInfo == null)
        ////    {
        ////        return Unauthorized("Invalid Google Token");
        ////    }

        ////    var userId = googleUserInfo.Subject; // Google user ID
        ////    var email = googleUserInfo.Email;

        ////    // You can implement user sign-in logic here

        ////    // Create JWT Token
        ////    var claims = new[]
        ////    {
        ////        new Claim(ClaimTypes.Name, email),
        ////        new Claim(ClaimTypes.NameIdentifier, userId),
        ////        new Claim(ClaimTypes.Email, email),
        ////    };

        ////    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
        ////    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        ////    var tokenDescriptor = new JwtSecurityToken(
        ////        issuer: _config["Jwt:Issuer"],
        ////        audience: _config["Jwt:Audience"],
        ////        claims: claims,
        ////        expires: DateTime.Now.AddDays(1),
        ////        signingCredentials: creds);

        ////    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        ////    return Ok(new { Token = tokenString });
        ////}


        ////// POST: api/user/signout
        ////[HttpPost("Googlesignout")]
        ////[Authorize]
        ////public IActionResult GoogleSignOut()
        ////{
        ////    // Invalidate the JWT Token by clearing it on the client-side
        ////    return Ok(new { Message = "Successfully signed out" });
        ////}
        ////// Helper Method: Verify Google Token
        ////private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string token)
        ////{
        ////    try
        ////    {
        ////        var clientId = _config["Google:ClientId"]; // store your Google client id here
        ////        return await GoogleJsonWebSignature.ValidateAsync(token,
        ////        new GoogleJsonWebSignature.ValidationSettings
        ////        {
        ////            Audience = new[] { clientId }
        ////        });
        ////        //var googlePayload = await GoogleJsonWebSignature.ValidateAsync(token);
        ////        //return googlePayload;
        ////    }
        ////    catch (Exception)
        ////    {
        ////        return null;
        ////    }
        ////}



        ////[HttpGet("google-login")]
        ////public IActionResult GoogleLogin()
        ////{
        ////    var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback") };
        ////    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        ////}

        ////[HttpGet("login-success")]
        ////public IActionResult LoginSuccess(string token)
        ////{
        ////    return Ok(new { message = "Google Login Successful", token });
        ////}

        ////[HttpGet("signin-google")]
        ////public async Task<IActionResult> GoogleCallback()
        ////{
        ////    var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        ////    if (!authenticateResult.Succeeded)
        ////        return BadRequest("Google authentication failed.");

        ////    var claims = authenticateResult.Principal.Identities.FirstOrDefault()?.Claims;
        ////    var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        ////    var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        ////    return Ok(new { Name = name, Email = email, Message = "Login successful!" });
        ////}


        //////-----------------------------------google end

    }
}


