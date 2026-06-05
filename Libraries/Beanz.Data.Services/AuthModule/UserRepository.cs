using AutoMapper;
using Beanz.Core.AuthModule;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.Models.AuthModule;
using Beanz.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Data.Services.AuthModule
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString; 

        private readonly IMapper _mapper;
        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        } 
        //public async Task<User?> GetByIdAsync(long userId)
        //{
        //    using var conn = Connection;
        //    return await conn.QueryFirstOrDefaultAsync<User>(
        //        "SELECT TOP 1 * FROM auth.Users WHERE UserID = @userId AND IsDeleted = 0;",
        //        new { userId });
        //}

        public async Task<EmailVerificationTokenResponseDTO> SaveEmailVerificationTokenAsync(EmailVerificationToken common)
        {
            //using var conn = Connection;
            //const string sql = @"
            //INSERT INTO auth.EmailVerificationTokens
            //    (UserID, Token, EmailAddress, ExpireDate, IPAddress)
            //VALUES (@UserID, @Token, @EmailAddress, @ExpireDate, @IPAddress);";
            //return await conn.ExecuteAsync(sql, token);

            try
            {
                string _sql = @"                
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User does not exist' ELSE N'المستخدم غير موجود' END,
                @MsgEmailNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email address does not exist' ELSE N'أو الأفضل والأكثر استخدامًا في الأنظمة' END,
                @MsgEmailVerificationTokenSuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                
                select @UserName= UserName from auth.Users WHERE UserID=@UserID
                
                IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE  UserID=@UserID)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserNotExists
                        RETURN;
                      END
                IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE EmailAddress = @EmailAddress)
                    BEGIN
                        set @Success=0 
                        set @Message=@MsgEmailNotExists
                        RETURN
                    END
                BEGIN
                    UPDATE [auth].[EmailVerificationTokens] SET IsDeleted=1 where EmailAddress=@EmailAddress
                    INSERT INTO [auth].[EmailVerificationTokens]
                        (UserID, Token, EmailAddress, ExpireDate, IPAddress)
                    VALUES
                        (@UserID, @Token, @EmailAddress, @ExpireDate, @IPAddress)

                    SET @EmailVerificationTokenID = SCOPE_IDENTITY();
                    set @Success=1 
                    SET @Message =@MsgEmailVerificationTokenSuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = common.UserID },
                    new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = common.UserName },
                    new SqlParameter("@Token", SqlDbType.NVarChar) { Value = common.Token },
                    new SqlParameter("@EmailAddress", SqlDbType.NVarChar) { Value = common.EmailAddress },
                    new SqlParameter("@ExpireDate", SqlDbType.NVarChar) { Value = common.ExpireDate },
                    new SqlParameter("@IPAddress", SqlDbType.NVarChar) { Value = common.IPAddress }, 
                    new SqlParameter("@LanguageID", SqlDbType.Int) { Value = common.LanguageID } ,

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@EmailVerificationTokenID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<EmailVerificationTokenResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                EmailVerificationTokenResponseDTO authSignupResponseDTO = new EmailVerificationTokenResponseDTO();
                authSignupResponseDTO.Success = false;
                authSignupResponseDTO.Message = ex.Message;
                return authSignupResponseDTO;
            }
        }

        public async Task<EmailVerificationToken?> GetEmailVerificationTokenAsync(string token)
        {
            return await SQLDataAccessLayer.SingleBySqlAsync<EmailVerificationToken>(
                "SELECT TOP 1 * FROM auth.EmailVerificationTokens WHERE IsDeleted=0 and IsActive=1 and Token = @token;", new { token });
        }

        public async Task MarkEmailVerifiedAsync(int? userId, int? tokenId)
        {
            //using var conn = Connection;
            //conn.Open();
            //using var tx = conn.BeginTransaction();
            try
            {
                const string sql = @"
                    BEGIN TRAN;
                    BEGIN TRY
                        UPDATE auth.EmailVerificationTokens
                        SET IsUsed = 1, UsedDate = SYSUTCDATETIME()
                        WHERE IsDeleted=0 and IsActive=1 and TokenID = @tokenId;

                        UPDATE auth.Users
                        SET EmailVerified = 1, IsActive = 1, ModifiedDate = SYSUTCDATETIME()
                        WHERE UserID = @userId;

                        COMMIT TRAN;
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRAN;
                        THROW;
                    END CATCH;";


                await SQLDataAccessLayer.ExecuteScalarSqlAsync(sql, new { tokenId, userId });

                //await SQLDataAccessLayer.ExecuteScalarSqlAsync(@"
                //UPDATE auth.EmailVerificationTokens
                //SET IsUsed = 1, UsedDate = SYSUTCDATETIME()
                //WHERE TokenID = @tokenId;", new { tokenId }, tx);

                //await SQLDataAccessLayer.ExecuteScalarSqlAsync(@"
                //UPDATE auth.Users
                //SET EmailVerified = 1, IsActive = 1, ModifiedDate = SYSUTCDATETIME()
                //WHERE UserID = @userId;", new { userId }, tx);

                //tx.Commit();
            }
            catch
            { 
                throw;
            }
        }

        public async Task<User?> GetByIdentifierAsync(string identifier)
        {
            //return await SQLDataAccessLayer.QueryFirstOrDefaultAsync<EmailVerificationToken>(
            //    "SELECT TOP 1 * FROM auth.EmailVerificationTokens WHERE Token = @token;", new { token });
            //using var conn = Connection;
            return await SQLDataAccessLayer.SingleBySqlAsync<User>(
                @"SELECT TOP 1 * FROM auth.Users
              WHERE (UserName = @id OR EmailAddress = @id) AND IsDeleted = 0;",
                new { id = identifier });
        }

        public async Task<User?> GetByIdAsync(int _userId)
        {
             
            return await SQLDataAccessLayer.SingleBySqlAsync<User>(
                "SELECT TOP 1 * FROM auth.Users WHERE UserID = @userId AND IsDeleted = 0;",
                new { userId=_userId });
        }
    }
}
