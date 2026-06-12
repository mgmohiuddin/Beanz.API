using AutoMapper;
using Beanz.Core.AuthModule;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.DTOs.Auth;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.Models.AuthModule;
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
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {


        private readonly IMapper _mapper;
        private readonly string _connectionString;
        public PasswordResetTokenRepository(IMapper mapper, IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SqlConnectionString")!;
            _mapper = mapper;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<ForgetPasswordRequestResponseDTO> ForgetPasswordRequestAsync(string email, int languageID = 1)
        {
            try
            {
                string _sql = @"
            set @LanguageID = IsNull(@LanguageID,1)
            DECLARE
                @MsgEmailNotFound NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email not found' ELSE N'البريد الإلكتروني غير موجود' END,
                @MsgInactive      NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User is not active' ELSE N'المستخدم غير نشط' END,
                @MsgOk            NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Reset link sent' ELSE N'تم إرسال رابط إعادة التعيين' END;

            DECLARE @uid INT, @fname NVARCHAR(200), @active BIT;

            SELECT TOP 1 @uid = UserID, @fname = FullName, @active = IsActive
            FROM auth.Users WHERE EmailAddress = @EmailAddress;

            IF (@uid IS NULL)
            BEGIN
                SET @Success = 0; SET @Message = @MsgEmailNotFound;
                SET @UserID = 0; SET @FullName = N'';
                RETURN;
            END

            IF (@active = 0)
            BEGIN
                SET @Success = 0; SET @Message = @MsgInactive;
                SET @UserID = @uid; SET @FullName = ISNULL(@fname,N'');
                RETURN;
            END

            -- invalidate previous unused tokens for this user
            UPDATE auth.PasswordResetTokens
               SET Used = 1, UsedAt = SYSUTCDATETIME()
             WHERE UserID = @uid AND Used = 0;

            SET @Success = 1;
            SET @Message = @MsgOk;
            SET @UserID  = @uid;
            SET @FullName = ISNULL(@fname,N'');
        ";

                SqlParameter[] parameters =
                {
            new SqlParameter("@EmailAddress", SqlDbType.NVarChar) { Value = email },
            new SqlParameter("@LanguageID",   SqlDbType.Int)      { Value = languageID },

            new SqlParameter("@Success",  SqlDbType.Bit)               { Direction = ParameterDirection.Output },
            new SqlParameter("@Message",  SqlDbType.NVarChar, 400)     { Direction = ParameterDirection.Output },
            new SqlParameter("@UserID",   SqlDbType.Int)               { Direction = ParameterDirection.Output },
            new SqlParameter("@FullName", SqlDbType.NVarChar, 200)     { Direction = ParameterDirection.Output },
        };

                var result = await SQLDataAccessLayer.MultipleOutputBySqlAsync<ForgetPasswordRequestResponseDTO>(_sql, parameters);
                result.EmailAddress = email;
                return result;
            }
            catch (Exception ex)
            {
                return new ForgetPasswordRequestResponseDTO { Success = false, Message = ex.Message };
            }
        }

        // 2) Save the generated token hash (1-hour expiry decided by caller/service)
        public async Task<bool> SavePasswordResetTokenAsync(SavePasswordResetTokenDTO dto)
        {
            try
            {
                string _sql = @"
            INSERT INTO auth.PasswordResetTokens (UserID, TokenHash, ExpiresAt, Used, CreatedAt)
            VALUES (@UserID, @TokenHash, @ExpiresAt, 0, SYSUTCDATETIME());
            SET @Success = 1;
            SET @Message = N'OK';
        ";

                SqlParameter[] parameters =
                {
            new SqlParameter("@UserID",    SqlDbType.Int)            { Value = dto.UserID },
            new SqlParameter("@TokenHash", SqlDbType.NVarChar, 256)  { Value = dto.TokenHash },
            new SqlParameter("@ExpiresAt", SqlDbType.DateTime2)      { Value = dto.ExpiresAt },

            new SqlParameter("@Success",  SqlDbType.Bit)             { Direction = ParameterDirection.Output },
            new SqlParameter("@Message",  SqlDbType.NVarChar, 200)   { Direction = ParameterDirection.Output },
        };

                var r = await SQLDataAccessLayer.MultipleOutputBySqlAsync<ResetPasswordResponseDTO>(_sql, parameters);
                return r.Success;
            }
            catch { return false; }
        }

        // 3) Validate the token + update password + mark token used (single transactional batch)
        public async Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordRequestDTO dto)
        {
            try
            {
                string _sql = @"
                set @LanguageID= IsNull(@LanguageID,1)
                 
            BEGIN TRAN;
                UPDATE auth.Users
                   SET PasswordHash = @NewPasswordHash,
                       LastPasswordChangedDate = SYSUTCDATETIME(),
                       ModifiedDate = SYSUTCDATETIME()
                 WHERE UserID = @PUserID;

                UPDATE auth.PasswordResetTokens
                   SET IsUsed = 1, UsedDate = SYSUTCDATETIME()
                 WHERE Token = @TokenHash;

                -- also invalidate any other outstanding tokens
                UPDATE auth.PasswordResetTokens
                   SET IsDeleted = 1 
                 WHERE  UserID = @PUserID;
            COMMIT TRAN;

            SET @Success = 1; SET @Message = 'Password Reset Successfully'; SET @UserID = @PUserID;
        ";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@EmailAddress",    SqlDbType.NVarChar)  { Value = dto.EmailAddress },
                    new SqlParameter("@TokenHash",       SqlDbType.NVarChar)  { Value = dto.Token },
                    new SqlParameter("@NewPasswordHash", SqlDbType.NVarChar)  { Value = dto.NewPassword },
                    new SqlParameter("@NewPasswordSalt", SqlDbType.NVarChar)  { Value = dto.NewPasswordSalt },
                    new SqlParameter("@LanguageID",      SqlDbType.Int)       { Value = dto.LanguageID },
                    new SqlParameter("@PUserID",         SqlDbType.Int)       { Value = dto.UserID },

                    new SqlParameter("@Success", SqlDbType.Bit)             { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar, 400)   { Direction = ParameterDirection.Output },
                    new SqlParameter("@UserID",  SqlDbType.Int)             { Direction = ParameterDirection.Output },
                };

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<ResetPasswordResponseDTO>(_sql, parameters);
            }
            catch (Exception ex)
            {
                return new ResetPasswordResponseDTO { Success = false, Message = ex.Message };
            }
        }

          

        
    }
}
