using AutoMapper;
//using Beanz.DTOs.Administration.Security;
//using Beanz.DTOs.SupplyChainManagment.Transactions.Transfers.StoreProcedureDTO;
using Beanz.Core.AuthModule;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.Data.Services.DataAccessLayer.DAL;
 
using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.RequestResponse.Request;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
//using Beanz.Core.Administration.Security;
using Beanz.DTOs.Common;
using Beanz.Models.AuthModule;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Data.Services.AuthModule
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly string _connectionString;
        public AuthRepository(IMapper mapper, IConfiguration config)
        {
             _connectionString = config.GetConnectionString("SqlConnectionString")!;
            _mapper = mapper;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);



        public async Task<AuthSignupResponseDTO> SignUpAsync(User common)
        {
            try
            {
                string _sql = @"                
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserAlreadyExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User Already Exists' ELSE N'المستخدم موجود بالفعل' END,
                @MsgEmailAlreadyExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email Already Exists' ELSE N'المستخدم موجود بالفعل' END,
                @MsgUserRegisteredSuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User Registered Success' ELSE N'تم تسجيل المستخدم بنجاح' END;
                IF EXISTS (SELECT 1 FROM auth.Users WHERE UserName = @UserName)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserAlreadyExists
                        RETURN;
                      END
                IF EXISTS (SELECT 1 FROM auth.Users WHERE EmailAddress = @EmailAddress)
                    BEGIN
                        set @Success=0 
                        set @Message=@MsgEmailAlreadyExists
                        RETURN
                    END
                BEGIN
                    INSERT INTO [auth].[Users]
                        (UserName, FullName, EmailAddress, PasswordHash, PasswordSalt,MobileNumber, CountryCode, ProfilePictureUrl, AvatarUrl,
                        PreferredLanguage, TimeZone, IsActive, EmailVerified, CreatedDate)
                    VALUES
                        (@UserName, @FullName, @EmailAddress, @PasswordHash, @PasswordSalt,
                        @MobileNumber, @CountryCode, @ProfilePictureUrl, @AvatarUrl,
                        @LanguageID, @TimeZone, 0, 0, SYSUTCDATETIME())

                   
                    SET @UserID = SCOPE_IDENTITY();
                    IF (@UserName = 'Administrator')
                    BEGIN
                        UPDATE [auth].[Users] SET [EmailVerified]=1 WHERE UserID= @UserID

                        INSERT INTO [auth].[UserCompanies] (UserID,CompanyID,CreatedBy) Values (@UserID, 1 ,@UserID )
                    END

                    set @Success=1
                    SET @UserID =@UserID 
                    SET @Message =@MsgUserRegisteredSuccess
                END";
                SqlParameter[] parameters =
                { 
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = common.UserName },
                    new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = common.FullName },
                    new SqlParameter("@EmailAddress", SqlDbType.NVarChar) { Value = common.EmailAddress },
                    new SqlParameter("@PasswordHash", SqlDbType.NVarChar) { Value = common.PasswordHash },
                    new SqlParameter("@PasswordSalt", SqlDbType.NVarChar) { Value = common.PasswordSalt },
                    new SqlParameter("@MobileNumber", SqlDbType.NVarChar) { Value = common.MobileNumber },
                    new SqlParameter("@CountryCode", SqlDbType.NVarChar) { Value = common.CountryCode },
                    new SqlParameter("@ProfilePictureUrl", SqlDbType.NVarChar) { Value = common.ProfilePictureUrl },
                    new SqlParameter("@AvatarUrl", SqlDbType.NVarChar) { Value = common.AvatarUrl },
                    new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID },
                    new SqlParameter("@TimeZone", SqlDbType.NVarChar) { Value = common.TimeZone },

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output }, 
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<AuthSignupResponseDTO>(_sql, parameters);
             

            }
            catch (Exception ex)
            {
                
                    AuthSignupResponseDTO authSignupResponseDTO = new AuthSignupResponseDTO();
                    authSignupResponseDTO.Success = false;
                    authSignupResponseDTO.Message = ex.Message;
                    return authSignupResponseDTO;
               
                
            }
          
        }

        public async Task<IEnumerable<UserCompanies>> GetUserCompanyAsync(User common)
        {
            string sql = @"
                        SELECT CO.*
                        FROM [auth].[UserCompanies] UC
                        INNER JOIN [auth].[Companies] CO 
                            ON UC.CompanyID = CO.CompanyID
                        WHERE ISNULL(CO.IsApproved, 0) = 1
                          AND ISNULL(CO.IsDeleted, 0) = 0
                          AND UC.UserID = @UserID;
                    ";
            
            return await SQLDataAccessLayer.ListBySqlAsync<UserCompanies>(
               sql,
               new
               {
                   UserID = common.UserID
               });

            //return (await SQLDataAccessLayer.ListBySqlAsync<UserCompanies>(
            //       sql,
            //       new
            //       {
            //           UserID = common.UserID
            //       })).ToList();
        }
       
        public async Task<AuthLoginAttemptResponseDTO> LoginAttemptAsync(LoginAttempt attempt)
        {
            string _sql = @" 
            
            INSERT INTO auth.LoginAttempts
                (UserID, UserName, IPAddress, UserAgent, IsSuccess, FailureReason, AttemptDate)
            VALUES
                (@P_UserID, @UserName, @IPAddress, @UserAgent, @IsSuccess, @FailureReason, SYSUTCDATETIME()); 

            Set @LoginAttemptID= SCOPE_IDENTITY();
            set @Success=1;
            set @Message='Login Attempt Register'

            IF (@IsSuccess = 0 AND ISNULL(@P_UserID, 0) <> 0)
            BEGIN
                UPDATE auth.Users
                SET FailedLoginAttempts = FailedLoginAttempts + 1,
                    IsLocked = CASE WHEN FailedLoginAttempts + 1 >= @maxFailedAttempts THEN 1 ELSE IsLocked END,
                    LockoutEndDate = CASE WHEN FailedLoginAttempts + 1 >= @maxFailedAttempts
                                          THEN DATEADD(MINUTE, @lockoutMinutes, SYSUTCDATETIME())
                                          ELSE LockoutEndDate END
                WHERE UserID = @P_UserID;
                --set @UserID= @P_UserID;
            END
            
            ";

            SqlParameter[] parameters =
               {
                    new SqlParameter("@P_UserID", SqlDbType.Int) { Value = attempt.UserID },
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = attempt.UserName },
                    new SqlParameter("@IPAddress", SqlDbType.NVarChar) { Value = attempt.IPAddress },
                    new SqlParameter("@UserAgent", SqlDbType.NVarChar) { Value = attempt.UserAgent },
                    new SqlParameter("@IsSuccess", SqlDbType.Bit) { Value = attempt.IsSuccess },
                    new SqlParameter("@FailureReason", SqlDbType.NVarChar) { Value = attempt.FailureReason },
                     new SqlParameter("@maxFailedAttempts", SqlDbType.Int) { Value = attempt.maxFailedAttempts },
                    new SqlParameter("@lockoutMinutes", SqlDbType.Int) { Value = attempt.lockoutMinutes },

                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@LoginAttemptID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
            return await SQLDataAccessLayer.MultipleOutputBySqlAsync<AuthLoginAttemptResponseDTO>(_sql, parameters);
            // await SQLDataAccessLayer.ExecuteScalarSqlAsync(_sql , parameters);
        }

        public async Task UpdateLoginSuccessAsync(int? userId)
        {
            using var conn = Connection;
            await conn.ExecuteAsync(@"
            UPDATE auth.Users
            SET FailedLoginAttempts = 0,
                IsLocked = 0,
                LockoutEndDate = NULL,
                LastLoginDate = SYSUTCDATETIME()
            WHERE UserID = @userId;", new { userId });
        }

        public async Task UpdateLoginFailureAsync(int? userId, int maxFailedAttempts, int lockoutMinutes)
        {
            using var conn = Connection;
            await conn.ExecuteAsync(@"
            UPDATE auth.Users
            SET FailedLoginAttempts = FailedLoginAttempts + 1,
                IsLocked = CASE WHEN FailedLoginAttempts + 1 >= @maxFailedAttempts THEN 1 ELSE IsLocked END,
                LockoutEndDate = CASE WHEN FailedLoginAttempts + 1 >= @maxFailedAttempts
                                      THEN DATEADD(MINUTE, @lockoutMinutes, SYSUTCDATETIME())
                                      ELSE LockoutEndDate END
            WHERE UserID = @userId;",
                new { userId, maxFailedAttempts, lockoutMinutes });
        }


        public async Task<IEnumerable<UserMenu>> GetUserMenuAsync(BeanzRequestDTO common)
        {
            string sql = @"ses.GetMenuTree";

            return await SQLDataAccessLayer.ListBySpAsync<UserMenu>(
               sql,
               new
               {
                   UserID = common.UserID
               });

            //return (await SQLDataAccessLayer.ListBySqlAsync<UserCompanies>(
            //       sql,
            //       new
            //       {
            //           UserID = common.UserID
            //       })).ToList();
        }

        //public async Task<AuthSignInResponseDTO> SignInAsync(AuthSignInRequestDTO authSignInRequestDTO)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<AuthSignInDTO> SignInAsync(AuthSignInDTO SignIn)
        //{
        //    try
        //    {
        //        string _sql = "auth.SignIn";
        //        SqlParameter[] paramList = {
        //         new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = SignIn.CompanyID
        //        },
        //          new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = SignIn.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.UserName
        //        },
        //        new SqlParameter("@Password", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.Password
        //        },
        //        new SqlParameter("@Type", SqlDbType.Int)
        //        {
        //            Value=SignIn.Type
        //        },
        //        new SqlParameter("@googleSub", SqlDbType.NVarChar)
        //        {
        //            Value=SignIn.googleSub
        //        }
        //    };
        //        var _User = await DAL.GetObjectListWithParametersAsync<AuthSignInDTO>(_sql, paramList);
        //        var authResponseDTO =  _User.FirstOrDefault();
        //        return authResponseDTO;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    //return _User;
        //}

        //public async Task<AuthResponseDTO> SignOutAsync(AuthSignOutDTO common)
        //{
        //    string _sql = "auth.SignOut";
        //    SqlParameter[] paramList = {
        //        new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = common.CompanyID
        //        },
        //        new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = common.UserID
        //        },
        //         new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value = common.UserName
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value = common.Email
        //        }

        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthSignOutDTO>(_sql, paramList);
        //    var authResponseDTO = _mapper.Map<AuthResponseDTO>(_User);
        //    return authResponseDTO;
        //}

        //public async Task<AuthResponseDTO> ForgetPasswordAsync(AuthForgetPasswordDTO SignIn)
        //{
        //    string _sql = "auth.ForgetPassword";
        //    SqlParameter[] paramList = {
        //         new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = SignIn.CompanyID
        //        },
        //          new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = SignIn.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.UserName
        //        } 
        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthForgetPasswordDTO>(_sql, paramList);
        //    var authResponseDTO = _mapper.Map<AuthResponseDTO>(_User);
        //    return authResponseDTO;

        //}

        //public async Task<AuthResponseDTO> ChangePasswordAsync(AuthChangePasswordDTO common)
        //{
        //    string _sql = "auth.ChangePassword";
        //    SqlParameter[] paramList = {
        //         new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = common.CompanyID
        //        },
        //          new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = common.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value =common.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value =common.UserName
        //        },
        //         new SqlParameter("@OldPassword", SqlDbType.NVarChar)
        //        {
        //            Value =common.OldPassword
        //        },
        //        new SqlParameter("@NewPassword", SqlDbType.NVarChar)
        //        {
        //            Value =common.NewPassword
        //        },
        //        new SqlParameter("@ConfirmPassword", SqlDbType.NVarChar)
        //        {
        //            Value =common.ConfirmPassword
        //        },

        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthResponseDTO>(_sql, paramList);
        //    var authResponseDTO = _User.FirstOrDefault();
        //    return authResponseDTO;
        //}

        //public async Task<AuthResponseDTO> ResetPasswordAsync(AuthResetPasswordDTO common)
        //{
        //    try
        //    {
        //        string _sql = "auth.ResetPassword";
        //        SqlParameter[] paramList = {
        //         new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = common.CompanyID
        //        },
        //          new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = common.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value =common.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value =common.UserName
        //        },
        //         new SqlParameter("@SecretKey", SqlDbType.NVarChar)
        //        {
        //            Value =common.SecretKey
        //        },
        //        new SqlParameter("@NewPassword", SqlDbType.NVarChar)
        //        {
        //            Value =common.NewPassword
        //        },
        //        new SqlParameter("@ConfirmPassword", SqlDbType.NVarChar)
        //        {
        //            Value =common.ConfirmPassword
        //        },
        //    };
        //        var _User = await DAL.GetObjectListWithParametersAsync<AuthResponseDTO>(_sql, paramList);
        //        var authResponseDTO = _User.FirstOrDefault();
        //        return authResponseDTO;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //public async Task<AuthResponseDTO> LockUserAsync(AuthSignInDTO common)
        //{
        //    string _sql = "auth.LockUser";
        //    SqlParameter[] _parameters = {
        //        new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = common.CompanyID
        //        },
        //        new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = common.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value = common.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value = common.UserName
        //        },
        //        new SqlParameter("@Password", SqlDbType.NVarChar)
        //        {
        //            Value = common.Password
        //        }
        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthForgetPasswordDTO>(_sql, _parameters);
        //    var authResponseDTO = _mapper.Map<AuthResponseDTO>(_User);
        //    return authResponseDTO;

        //    //string result = await DAL.ExecuteSetWithSingleOutputParametersAsync(_sql, "@ReturnValue", _parameters);
        //    //AuthResponseDTO authResponseDTO = new AuthResponseDTO();
        //    //authResponseDTO.Message = result;
        //    //return authResponseDTO;
        //}

        //public async Task<AuthResponseDTO> UnLockUserAsync(AuthForgetPasswordDTO SignIn)
        //{
        //    string _sql = "auth.UnLockUser";
        //    SqlParameter[] paramList = {
        //         new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = SignIn.CompanyID
        //        },
        //          new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = SignIn.UserID
        //        },
        //        new SqlParameter("@Email", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.Email
        //        },
        //        new SqlParameter("@UserName", SqlDbType.NVarChar)
        //        {
        //            Value =SignIn.UserName
        //        }
        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthForgetPasswordDTO>(_sql, paramList);
        //    var authResponseDTO = _mapper.Map<AuthResponseDTO>(_User);
        //    return authResponseDTO;

        //}

        //public async Task<AuthResponseDTO> LoginAttemptsAsync(AuthSignInDTO common)
        //{
        //    string _sql = "auth.LoginAttempts";
        //    SqlParameter[] _parameters = {
        //        new SqlParameter("@CompanyID", SqlDbType.Int)
        //        {
        //            Value = common.CompanyID
        //        },
        //        new SqlParameter("@UserID", SqlDbType.INT)
        //        {
        //            Value = common.UserID
        //        },
        //        new SqlParameter("@IsFail", SqlDbType.NVarChar)
        //        {
        //            Value = common.IsFail
        //        },
        //         new SqlParameter("@Token", SqlDbType.NVarChar)
        //        {
        //            Value = common.Token
        //        },

        //    };
        //    var _User = await DAL.GetObjectListWithParametersAsync<AuthResponseDTO>(_sql, _parameters);
        //    var authResponseDTO = _User.FirstOrDefault();
        //    return authResponseDTO; 

        //}

        //public async Task<ForgetPasswordRequestResponseDTO> ForgetPasswordRequestAsync(string email, int langId)
        //{
        //    var lookup = await _passwordResetTokenRepository.ForgetPasswordRequestAsync(email, langId);
        //    if (!lookup.Success) return lookup;

        //    // generate raw token + hash
        //    var rawBytes = RandomNumberGenerator.GetBytes(48);
        //    var rawToken = Convert.ToBase64String(rawBytes).Replace("+", "-").Replace("/", "_").TrimEnd('=');
        //    var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawToken));
        //    var tokenHash = Convert.ToBase64String(hashBytes);

        //    await _passwordResetTokenRepository.SavePasswordResetTokenAsync(new SavePasswordResetTokenDTO
        //    {
        //        UserID = lookup.UserID,
        //        TokenHash = tokenHash,
        //        ExpiresAt = DateTime.UtcNow.AddHours(1),
        //        LanguageID = langId
        //    });

        //    var link = $"{_uiBaseUrl}/reset-password?email={Uri.EscapeDataString(email)}&token={rawToken}";
        //    await _emailService.SendPasswordResetAsync(email, lookup.FullName, link);

        //    return lookup;
        //}


    }
}
