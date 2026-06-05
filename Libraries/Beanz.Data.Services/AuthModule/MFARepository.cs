using AutoMapper;
using Beanz.Core.AuthModule;
using Beanz.Data.Services.DataAccessLayer;
using Beanz.DTOs.AuthModule.EmailDTOs;
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.Models.AuthModule;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Beanz.Data.Services.AuthModule
{
    public class MFARepository : IMFARepository
    {
        //private readonly string _connectionString;
        //public MFARepository(IConfiguration config)
        //    => _connectionString = config.GetConnectionString("DefaultConnection")!;

        ////private IDbConnection Connection => new SqlConnection(_connectionString);

        private readonly IMapper _mapper;
        public MFARepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<UserMFA?> GetUserMFAAsync(int? userId)
        {
            return await SQLDataAccessLayer.SingleBySqlAsync<UserMFA>(
              " SELECT TOP 1 * FROM auth.UserMFA WHERE UserID = @userId; ", new { userId });
        }

        public async Task<UserMFAResponseDTO> UpsertUserMFAAsync(UserMFA mfa)
        {

            try
            {
                string _sql = @"                
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User does not exist' ELSE N'المستخدم غير موجود' END,
                @MsgEmailNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email address does not exist' ELSE N'أو الأفضل والأكثر استخدامًا في الأنظمة' END,
                @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                
               IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE  UserID=@UserID)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserNotExists
                        RETURN;
                      END
                
                BEGIN
                    MERGE auth.UserMFA AS tgt
                    USING (SELECT @UserID AS UserID) AS src
                      ON tgt.UserID = src.UserID
                    WHEN MATCHED THEN
                        UPDATE SET MFAType = @MFAType, SecretKey = @SecretKey,
                                   IsEnabled = @IsEnabled, ModifiedDate = SYSUTCDATETIME()
                    WHEN NOT MATCHED THEN
                        INSERT (UserID, MFAType, SecretKey, IsEnabled)
                        VALUES (@UserID, @MFAType, @SecretKey, @IsEnabled);""

                    SET @UserMFAID = @UserID;
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = mfa.UserID },
                    new SqlParameter("@MFAType", SqlDbType.NVarChar) { Value = mfa.MFAType },
                    new SqlParameter("@SecretKey", SqlDbType.NVarChar) { Value = mfa.SecretKey },
                    new SqlParameter("@IsEnabled", SqlDbType.NVarChar) { Value = mfa.IsEnabled },
                   

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@UserMFAID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<UserMFAResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                UserMFAResponseDTO userMFAResponseDTO = new UserMFAResponseDTO();
                userMFAResponseDTO.Success = false;
                userMFAResponseDTO.Message = ex.Message;
                return userMFAResponseDTO;
            }
            //using var conn = Connection;
            //await conn.ExecuteAsync(@"
            //MERGE auth.UserMFA AS tgt
            //USING (SELECT @UserID AS UserID) AS src
            //  ON tgt.UserID = src.UserID
            //WHEN MATCHED THEN
            //    UPDATE SET MFAType = @MFAType, SecretKey = @SecretKey,
            //               IsEnabled = @IsEnabled, ModifiedDate = SYSUTCDATETIME()
            //WHEN NOT MATCHED THEN
            //    INSERT (UserID, MFAType, SecretKey, IsEnabled)
            //    VALUES (@UserID, @MFAType, @SecretKey, @IsEnabled);", mfa);
        }

        public async Task<UserMFAResponseDTO>SetMFAEnabledOnUserAsync(UserMFA mfa )
        {
            try
            {
                string _sql = @"                
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User does not exist' ELSE N'المستخدم غير موجود' END,
                @MsgEmailNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email address does not exist' ELSE N'أو الأفضل والأكثر استخدامًا في الأنظمة' END,
                @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                
                
                IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE  UserID=@UserID)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserNotExists
                        RETURN;
                      END
               
                BEGIN
                    UPDATE auth.Users SET MFAEnabled = @enabled, ModifiedDate = SYSUTCDATETIME() WHERE UserID = @UserID;

                    SET @UserMFAID = @UserID;
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = mfa.UserID },
                    new SqlParameter("@MFAType", SqlDbType.NVarChar) { Value = mfa.MFAType },
                    new SqlParameter("@SecretKey", SqlDbType.NVarChar) { Value = mfa.SecretKey },
                    new SqlParameter("@IsEnabled", SqlDbType.NVarChar) { Value = mfa.IsEnabled },
                   

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@UserMFAID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<UserMFAResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                UserMFAResponseDTO userMFAResponseDTO = new UserMFAResponseDTO();
                userMFAResponseDTO.Success = false;
                userMFAResponseDTO.Message = ex.Message;
                return userMFAResponseDTO;
            }
            //using var conn = Connection;
            //await conn.ExecuteAsync(
            //    "UPDATE auth.Users SET MFAEnabled = @enabled, ModifiedDate = SYSUTCDATETIME() WHERE UserID = @userId;",
            //    new { userId, enabled });
        }

        public async Task<MFAOTPResponseDTO> SaveOtpAsync(MFAOTP otp)
        {
            try
            {
                string _sql = @"  
 
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User does not exist' ELSE N'المستخدم غير موجود' END,
                @MsgEmailNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email address does not exist' ELSE N'أو الأفضل والأكثر استخدامًا في الأنظمة' END,
                @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                 
                
                IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE  UserID=@UserID)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserNotExists
                        RETURN;
                      END
                
                BEGIN
                     INSERT INTO auth.MFAOTPs
                        (UserID, MFAToken, OTPHash, MFAType, Purpose, ExpireDate, IPAddress)
                    VALUES
                        (@UserID, @MFAToken, @OTPHash, @MFAType, @Purpose, @ExpireDate, @IPAddress);

                    SET @MfaOtpID = SCOPE_IDENTITY();
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = otp.UserID },
                    new SqlParameter("@MFAToken", SqlDbType.NVarChar) { Value = otp.MFAToken },
                    new SqlParameter("@OTPHash", SqlDbType.NVarChar) { Value = otp.OTPHash },
                    new SqlParameter("@MFAType", SqlDbType.NVarChar) { Value = otp.MFAType },
                    new SqlParameter("@Purpose", SqlDbType.NVarChar) { Value = otp.Purpose },
                    new SqlParameter("@ExpireDate", SqlDbType.DateTime) { Value = otp.ExpireDate },
                    new SqlParameter("@IPAddress", SqlDbType.NVarChar) { Value = otp.IPAddress },
                    new SqlParameter("@LanguageID", SqlDbType.NVarChar) { Value = 1 },

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@MfaOtpID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<MFAOTPResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                MFAOTPResponseDTO mFAOTPResponseDTO = new MFAOTPResponseDTO();
                mFAOTPResponseDTO.Success = false;
                mFAOTPResponseDTO.Message = ex.Message;
                return mFAOTPResponseDTO;
            }
            
             
        }
        public async Task<UserMFA?> GetByUserIdAsync(int userId)
        {
            string _sql = @"   
                BEGIN
                    SELECT TOP 1 UserMFAID, UserID, MFAType, SecretKey, IsEnabled, CreatedDate, ModifiedDate
                            FROM auth.UserMFA WHERE IsEnabled=1 and IsActive=1 UserID = @UserID; 
                END";
            SqlParameter[] parameters =
               {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = userId }   
                };
            return await SQLDataAccessLayer.SingleBySqlAsync<UserMFA>(_sql, parameters);
        }

        // Insert if missing, else update SecretKey + MFAType (does NOT auto-enable)
        public async Task<MFAOTPResponseDTO> UpsertAsync(UserMFA mfa)
        {

            try
            {
                string _sql = @"  
 
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                @MsgUserNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'User does not exist' ELSE N'المستخدم غير موجود' END,
                @MsgEmailNotExists NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Email address does not exist' ELSE N'أو الأفضل والأكثر استخدامًا في الأنظمة' END,
                @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                 
                
                IF NOT EXISTS (SELECT 1 FROM auth.Users WHERE  UserID=@UserID)
                      BEGIN
                        set @Success=0
                        set @Message=@MsgUserNotExists
                        RETURN;
                      END
                
                BEGIN
                    MERGE auth.UserMFA AS T
                        USING (SELECT @UserID AS UserID) AS S
                            ON T.UserID = S.UserID
                        WHEN MATCHED THEN
                            UPDATE SET MFAType = @MFAType,
                                        SecretKey = @SecretKey,
                                        ModifiedDate = SYSUTCDATETIME()
                        WHEN NOT MATCHED THEN
                            INSERT (UserID, MFAType, SecretKey, IsEnabled)
                            VALUES (@UserID, @MFAType, @SecretKey, 0)
                        OUTPUT inserted.UserMFAID;

                    SET @MfaOtpID = SCOPE_IDENTITY();
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = mfa.UserID },
                    new SqlParameter("@MFAToken", SqlDbType.NVarChar) { Value = mfa.SecretKey },
                    new SqlParameter("@OTPHash", SqlDbType.NVarChar) { Value = mfa.IsEnabled },
                    new SqlParameter("@MFAType", SqlDbType.NVarChar) { Value = mfa.MFAType },
                    //new SqlParameter("@Purpose", SqlDbType.NVarChar) { Value = mfa.Purpose },
                    //new SqlParameter("@ExpireDate", SqlDbType.DateTime) { Value = mfa.ExpireDate },
                    //new SqlParameter("@IPAddress", SqlDbType.NVarChar) { Value = mfa.IPAddress },
                    new SqlParameter("@LanguageID", SqlDbType.NVarChar) { Value = 1 },

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@MfaOtpID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<MFAOTPResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                MFAOTPResponseDTO mFAOTPResponseDTO = new MFAOTPResponseDTO();
                mFAOTPResponseDTO.Success = false;
                mFAOTPResponseDTO.Message = ex.Message;
                return mFAOTPResponseDTO;
            }


            //const string sql = @"
            //                    MERGE auth.UserMFA AS T
            //                    USING (SELECT @UserID AS UserID) AS S
            //                       ON T.UserID = S.UserID
            //                    WHEN MATCHED THEN
            //                        UPDATE SET MFAType = @MFAType,
            //                                   SecretKey = @SecretKey,
            //                                   ModifiedDate = SYSUTCDATETIME()
            //                    WHEN NOT MATCHED THEN
            //                        INSERT (UserID, MFAType, SecretKey, IsEnabled)
            //                        VALUES (@UserID, @MFAType, @SecretKey, 0)
            //                    OUTPUT inserted.UserMFAID;";
            //return await SQLDataAccessLayer.ExecuteScalarSqlAsync<long>(sql, new
            //{
            //    mfa.UserID,
            //    mfa.MFAType,
            //    mfa.SecretKey
            //});
        }


        public async Task<bool> SetEnabledAsync(int userId, bool enabled)
        {
            const string sql = @"
                                UPDATE auth.UserMFA
                                   SET IsEnabled = @Enabled, ModifiedDate = SYSUTCDATETIME()
                                 WHERE UserID = @UserID;";
            SqlParameter[] parameters =
               {
                    new SqlParameter("@UserID", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@Enabled", SqlDbType.Bit) { Value = enabled },
                    
                    new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                };
            var rows = await SQLDataAccessLayer.MultipleOutputBySqlAsync<UserMFAResponseDTO>(sql, parameters); 
            return rows.Success;
        }

        public Task<bool> DisableAsync(int userId) => SetEnabledAsync(userId, false);




        public async Task<MFAOTP?> GetOtpByTokenAsync(string mfaToken)
        {
            try
            {
                return await SQLDataAccessLayer.SingleBySqlAsync<MFAOTP>(
                "SELECT TOP 1 * FROM auth.MFAOTPs WHERE MFAToken = @mfaToken;", new { mfaToken });
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<OTPResponseDTO> MarkOtpUsedAsync(long otpId, int LanguageID)
        {

            try
            {
                string _sql = @"        
                declare @LanguageID int=1
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                 @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                  
                
                BEGIN
                     UPDATE auth.MFAOTPs SET IsUsed = 1, UsedDate = SYSUTCDATETIME() WHERE OTPID = @otpId;

                    SET @otpId = otpId;
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@otpId", SqlDbType.Int) { Value = otpId },
                    new SqlParameter("@LanguageID", SqlDbType.Int) { Value = LanguageID }, 
                   

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@otpId", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<OTPResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                OTPResponseDTO mFAOTPResponseDTO = new OTPResponseDTO();
                mFAOTPResponseDTO.Success = false;
                mFAOTPResponseDTO.Message = ex.Message;
                return mFAOTPResponseDTO;
            }

            
           
        }

        public async Task<OTPResponseDTO> IncrementOtpRetryAsync(long otpId, int LanguageID)
        {
            try
            {
                string _sql = @"        
                declare @LanguageID int=1
                set @LanguageID= IsNull(@LanguageID,1)
                DECLARE                 
                 @MsgUserMFASuccess NVARCHAR(200) = CASE WHEN @LanguageID = 1 THEN N'Verification token has been generated and sent to the email successfully' ELSE N'تم إنشاء رمز التحقق وإرساله بنجاح' END;
                  
                
                BEGIN
                     UPDATE auth.MFAOTPs SET RetryCount = RetryCount + 1 WHERE OTPID = @otpId;

                    SET @otpId = otpId;
                    set @Success=1 
                    SET @Message =@MsgUserMFASuccess
                END";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@otpId", SqlDbType.Int) { Value = otpId },
                    new SqlParameter("@LanguageID", SqlDbType.Int) { Value = LanguageID }, 
                   

                    // output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                    new SqlParameter("@otpId", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<OTPResponseDTO>(_sql, parameters);


            }
            catch (Exception ex)
            {
                OTPResponseDTO mFAOTPResponseDTO = new OTPResponseDTO();
                mFAOTPResponseDTO.Success = false;
                mFAOTPResponseDTO.Message = ex.Message;
                return mFAOTPResponseDTO;
            }
            
         
        }
    }
}
