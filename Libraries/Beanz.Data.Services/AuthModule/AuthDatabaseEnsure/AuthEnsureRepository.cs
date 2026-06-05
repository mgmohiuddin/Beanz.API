using AutoMapper;
using Beanz.Core.AuthModule;
using Beanz.Core.AuthModule.AuthDatabaseEnsure;
using Beanz.Data.Services.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

using Beanz.DTOs.AuthModule.RequestResponse;
using Beanz.DTOs.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beanz.Models.AuthModule;
 

namespace Beanz.Data.Services.AuthModule.AuthDatabaseEnsure
{
    public class AuthEnsureRepository : IAuthEnsureRepository
    {
        private readonly IMapper _mapper;
        public AuthEnsureRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<GeneralResponseDTO> EnsureAuthSchemaAsync()
        {
            try
            {
                const string sql = @"
                                    IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END
                                    set @Success=1
                                    ";
                SqlParameter[] parameters =
              { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(sql, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureUsersTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                 IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'Users'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[Users]
                                        (
                                            [UserID] [int] IDENTITY(1,1) NOT NULL,
                                            [UserGuid] [uniqueidentifier] NOT NULL,
                                            [UserName] [nvarchar](100) NOT NULL,
                                            [FullName] [nvarchar](200) NOT NULL,
                                            [EmailAddress] [nvarchar](256) NOT NULL,
                                            [PasswordHash] [nvarchar](500) NULL,
                                            [PasswordSalt] [nvarchar](500) NULL,
                                            [MobileNumber] [nvarchar](20) NULL,
                                            [CountryCode] [nvarchar](10) NULL,
                                            [ProfilePictureUrl] [nvarchar](1000) NULL,
                                            [AvatarUrl] [nvarchar](1000) NULL,
                                            [AvatarName] [nvarchar](100) NULL,
                                            [Gender] [nvarchar](20) NULL,
                                            [DateOfBirth] [date] NULL,
                                            [PreferredLanguage] [nvarchar](10) NULL,
                                            [TimeZone] [nvarchar](100) NULL,
                                            [EmailVerified] [bit] NOT NULL,
                                            [MobileVerified] [bit] NOT NULL,
                                            [IsActive] [bit] NOT NULL,
                                            [IsDeleted] [bit] NOT NULL,
                                            [IsLocked] [bit] NOT NULL,
                                            [FailedLoginAttempts] [int] NOT NULL,
                                            [LockoutEndDate] [datetime2](3) NULL,
                                            [LastLoginDate] [datetime2](3) NULL,
                                            [LastPasswordChangedDate] [datetime2](3) NULL,
                                            [AllowMultipleLogin] [bit] NOT NULL,
                                            [MFAEnabled] [bit] NOT NULL,
                                            [CreatedDate] [datetime2](3) NOT NULL,
                                            [CreatedBy] [INT] NULL,
                                            [ModifiedDate] [datetime2](3) NULL,
                                            [ModifiedBy] [INT] NULL,

                                            CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID]),
                                            CONSTRAINT [UQ_Users_UserGuid] UNIQUE ([UserGuid]),
                                            CONSTRAINT [UQ_Users_UserName] UNIQUE ([UserName]),
                                            CONSTRAINT [UQ_Users_EmailAddress] UNIQUE ([EmailAddress])
                                        );

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_UserGuid] DEFAULT NEWID() FOR [UserGuid];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_PreferredLanguage] DEFAULT N'en' FOR [PreferredLanguage];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_TimeZone] DEFAULT N'UTC' FOR [TimeZone];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_EmailVerified] DEFAULT 0 FOR [EmailVerified];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_MobileVerified] DEFAULT 0 FOR [MobileVerified];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_IsActive] DEFAULT 0 FOR [IsActive];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_IsDeleted] DEFAULT 0 FOR [IsDeleted];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_IsLocked] DEFAULT 0 FOR [IsLocked];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_FailedLoginAttempts] DEFAULT 0 FOR [FailedLoginAttempts];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_AllowMultipleLogin] DEFAULT 1 FOR [AllowMultipleLogin];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_MFAEnabled] DEFAULT 0 FOR [MFAEnabled];

                                        ALTER TABLE [auth].[Users]
                                            ADD CONSTRAINT [DF_Users_CreatedDate] DEFAULT SYSUTCDATETIME() FOR [CreatedDate];

                                    END


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }, 
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql,@"^\s*GO\s*$","",System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                
                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureUserSessionsTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                IF NOT EXISTS
                                (
                                    SELECT 1
                                    FROM sys.tables t
                                    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                    WHERE s.name = 'auth'
                                        AND t.name = 'UserSessions'
                                )
                                BEGIN

                                    CREATE TABLE [auth].[UserSessions]
                                    (
                                        [SessionID] UNIQUEIDENTIFIER NOT NULL,
                                        [UserID] INT NOT NULL,
                                        [JWTTokenID] NVARCHAR(100) NOT NULL,
                                        [LoginDate] DATETIME2(3) NOT NULL,
                                        [LogoutDate] DATETIME2(3) NULL,
                                        [LastActivityDate] DATETIME2(3) NOT NULL,
                                        [IPAddress] NVARCHAR(64) NULL,
                                        [UserAgent] NVARCHAR(1000) NULL,
                                        [DeviceInfo] NVARCHAR(500) NULL,
                                        [BrowserName] NVARCHAR(100) NULL,
                                        [OperatingSystem] NVARCHAR(100) NULL,
                                        [IsActive] BIT NOT NULL,

                                        CONSTRAINT [PK_UserSessions]
                                            PRIMARY KEY CLUSTERED ([SessionID])
                                    );

                                    ALTER TABLE [auth].[UserSessions]
                                        ADD CONSTRAINT [DF_Sessions_SessionID]
                                        DEFAULT NEWID() FOR [SessionID];

                                    ALTER TABLE [auth].[UserSessions]
                                        ADD CONSTRAINT [DF_Sessions_LoginDate]
                                        DEFAULT SYSUTCDATETIME() FOR [LoginDate];

                                    ALTER TABLE [auth].[UserSessions]
                                        ADD CONSTRAINT [DF_Sessions_LastActivityDate]
                                        DEFAULT SYSUTCDATETIME() FOR [LastActivityDate];

                                    ALTER TABLE [auth].[UserSessions]
                                        ADD CONSTRAINT [DF_Sessions_IsActive]
                                        DEFAULT 1 FOR [IsActive];

                                    ALTER TABLE [auth].[UserSessions]
                                        ADD CONSTRAINT [FK_Sessions_Users]
                                        FOREIGN KEY ([UserID])
                                        REFERENCES [auth].[Users]([UserID])
                                        ON DELETE CASCADE;

                                    CREATE INDEX IX_UserSessions_UserID
                                        ON [auth].[UserSessions]([UserID]);

                                    CREATE INDEX IX_UserSessions_JWTTokenID
                                        ON [auth].[UserSessions]([JWTTokenID]);

                                    CREATE INDEX IX_UserSessions_IsActive
                                        ON [auth].[UserSessions]([IsActive]);

                                END


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureUserTokensTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                 IF NOT EXISTS
                                (
                                    SELECT 1
                                    FROM sys.tables t
                                    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                    WHERE s.name = 'auth'
                                        AND t.name = 'UserTokens'
                                )
                                BEGIN

                                    CREATE TABLE [auth].[UserTokens]
                                    (
                                        [UserTokenID] INT IDENTITY(1,1) NOT NULL,
                                        [UserID] INT NOT NULL,
                                        [JWTID] NVARCHAR(100) NOT NULL,
                                        [AccessToken] NVARCHAR(MAX) NOT NULL,
                                        [RefreshToken] NVARCHAR(500) NOT NULL,
                                        [IssueDate] DATETIME2(3) NOT NULL,
                                        [ExpireDate] DATETIME2(3) NOT NULL,
                                        [IsRevoked] BIT NOT NULL,
                                        [IsBlacklisted] BIT NOT NULL,
                                        [RevokedDate] DATETIME2(3) NULL,
                                        [RevokedReason] NVARCHAR(500) NULL,
                                        [DeviceInfo] NVARCHAR(500) NULL,
                                        [IPAddress] NVARCHAR(64) NULL,

                                        CONSTRAINT [PK_UserTokens]
                                            PRIMARY KEY CLUSTERED ([UserTokenID])
                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

                                    ALTER TABLE [auth].[UserTokens]
                                        ADD CONSTRAINT [DF_UT_IssueDate]
                                        DEFAULT SYSUTCDATETIME() FOR [IssueDate];

                                    ALTER TABLE [auth].[UserTokens]
                                        ADD CONSTRAINT [DF_UT_IsRevoked]
                                        DEFAULT 0 FOR [IsRevoked];

                                    ALTER TABLE [auth].[UserTokens]
                                        ADD CONSTRAINT [DF_UT_IsBlacklisted]
                                        DEFAULT 0 FOR [IsBlacklisted];

                                    ALTER TABLE [auth].[UserTokens]
                                        ADD CONSTRAINT [FK_UT_Users]
                                        FOREIGN KEY ([UserID])
                                        REFERENCES [auth].[Users]([UserID])
                                        ON DELETE CASCADE;

                                    CREATE INDEX IX_UserTokens_UserID
                                        ON [auth].[UserTokens]([UserID]);

                                    CREATE INDEX IX_UserTokens_JWTID
                                        ON [auth].[UserTokens]([JWTID]);

                                    CREATE INDEX IX_UserTokens_RefreshToken
                                        ON [auth].[UserTokens]([RefreshToken]);

                                    CREATE INDEX IX_UserTokens_ExpireDate
                                        ON [auth].[UserTokens]([ExpireDate]);

                                    CREATE INDEX IX_UserTokens_IsRevoked
                                        ON [auth].[UserTokens]([IsRevoked]);

                                    CREATE INDEX IX_UserTokens_IsBlacklisted
                                        ON [auth].[UserTokens]([IsBlacklisted]);

                                END
                                GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureRolesTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                 IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'Roles'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[Roles]
                                        (
                                            [RoleID] INT IDENTITY(1,1) NOT NULL,
                                            [RoleName] NVARCHAR(100) NOT NULL,
                                            [Description] NVARCHAR(500) NULL,
                                            [IsActive] BIT NOT NULL,
                                            [CreatedDate] DATETIME2(3) NOT NULL,
                                            [CreatedBy] INT NULL,
                                            [ModifiedDate] DATETIME2(3) NULL,
                                            [ModifiedBy] INT NULL,

                                            CONSTRAINT [PK_Roles]
                                                PRIMARY KEY CLUSTERED ([RoleID]),

                                            CONSTRAINT [UQ_Roles_RoleName]
                                                UNIQUE NONCLUSTERED ([RoleName])
                                        );

                                        ALTER TABLE [auth].[Roles]
                                            ADD CONSTRAINT [DF_Roles_IsActive]
                                            DEFAULT 1 FOR [IsActive];

                                        ALTER TABLE [auth].[Roles]
                                            ADD CONSTRAINT [DF_Roles_CreatedDate]
                                            DEFAULT SYSUTCDATETIME() FOR [CreatedDate];

                                    END
                                    GO

                                     -- Seed default roles
                                    IF NOT EXISTS (SELECT 1 FROM auth.Roles WHERE RoleName = N'Admin')
                                        INSERT INTO auth.Roles (RoleName, Description) VALUES (N'Admin', N'System administrator');

                                    IF NOT EXISTS (SELECT 1 FROM auth.Roles WHERE RoleName = N'User')
                                        INSERT INTO auth.Roles (RoleName, Description) VALUES (N'User',  N'Default role assigned on signup');
                                    GO

                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureUserRolesTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                  IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                          AND t.name = 'UserRoles'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[UserRoles]
                                        (
                                            [UserRoleID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NOT NULL,
                                            [RoleID] INT NOT NULL,
                                            [IsActive] BIT NOT NULL,
                                            [AssignedDate] DATETIME2(3) NOT NULL,
                                            [AssignedBy] INT NULL,

                                            CONSTRAINT [PK_UserRoles]
                                                PRIMARY KEY CLUSTERED ([UserRoleID]),

                                            CONSTRAINT [UQ_UserRoles_User_Role]
                                                UNIQUE NONCLUSTERED ([UserID], [RoleID])
                                        );

                                        ALTER TABLE [auth].[UserRoles]
                                            ADD CONSTRAINT [DF_UserRoles_IsActive]
                                            DEFAULT 1 FOR [IsActive];

                                        ALTER TABLE [auth].[UserRoles]
                                            ADD CONSTRAINT [DF_UserRoles_AssignedDate]
                                            DEFAULT SYSUTCDATETIME() FOR [AssignedDate];

                                        ALTER TABLE [auth].[UserRoles]
                                            ADD CONSTRAINT [FK_UserRoles_Roles]
                                            FOREIGN KEY ([RoleID])
                                            REFERENCES [auth].[Roles]([RoleID]);

                                        ALTER TABLE [auth].[UserRoles]
                                            ADD CONSTRAINT [FK_UserRoles_Users]
                                            FOREIGN KEY ([UserID])
                                            REFERENCES [auth].[Users]([UserID])
                                            ON DELETE CASCADE;

                                        CREATE INDEX IX_UserRoles_UserID
                                            ON [auth].[UserRoles]([UserID]);

                                        CREATE INDEX IX_UserRoles_RoleID
                                            ON [auth].[UserRoles]([RoleID]);

                                    END
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureLoginAttemptsTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                  IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'LoginAttempts'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[LoginAttempts]
                                        (
                                            [AttemptID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NULL,
                                            [UserName] NVARCHAR(256) NULL,
                                            [IPAddress] NVARCHAR(64) NULL,
                                            [UserAgent] NVARCHAR(1000) NULL,
                                            [IsSuccess] BIT NOT NULL,
                                            [FailureReason] NVARCHAR(500) NULL,
                                            [AttemptDate] DATETIME2(3) NOT NULL,

                                            CONSTRAINT [PK_LoginAttempts]
                                                PRIMARY KEY CLUSTERED ([AttemptID])
                                        );

                                        ALTER TABLE [auth].[LoginAttempts]
                                            ADD CONSTRAINT [DF_LA_AttemptDate]
                                            DEFAULT SYSUTCDATETIME() FOR [AttemptDate];

                                        ALTER TABLE [auth].[LoginAttempts]
                                            ADD CONSTRAINT [FK_LA_Users]
                                            FOREIGN KEY ([UserID])
                                            REFERENCES [auth].[Users]([UserID])
                                            ON DELETE SET NULL;

                                        CREATE INDEX IX_LoginAttempts_UserID
                                            ON [auth].[LoginAttempts]([UserID]);

                                        CREATE INDEX IX_LoginAttempts_UserName
                                            ON [auth].[LoginAttempts]([UserName]);

                                        CREATE INDEX IX_LoginAttempts_IPAddress
                                            ON [auth].[LoginAttempts]([IPAddress]);

                                        CREATE INDEX IX_LoginAttempts_AttemptDate
                                            ON [auth].[LoginAttempts]([AttemptDate]);

                                    END
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureExternalLoginsTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                   IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'ExternalLogins'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[ExternalLogins]
                                        (
                                            [ExternalLoginID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NOT NULL,
                                            [Provider] NVARCHAR(50) NOT NULL,
                                            [ProviderUserId] NVARCHAR(200) NOT NULL,
                                            [Email] NVARCHAR(256) NULL,
                                            [DisplayName] NVARCHAR(200) NULL,
                                            [PictureUrl] NVARCHAR(1000) NULL,
                                            [CreatedDate] DATETIME2(3) NOT NULL,
                                            [LastLoginDate] DATETIME2(3) NULL,

                                            CONSTRAINT [PK_ExternalLogins]
                                                PRIMARY KEY CLUSTERED ([ExternalLoginID]),

                                            CONSTRAINT [UQ_ExternalLogins_Provider]
                                                UNIQUE NONCLUSTERED ([Provider], [ProviderUserId])
                                        );

                                        ALTER TABLE [auth].[ExternalLogins]
                                            ADD CONSTRAINT [DF_ExtLogins_CreatedDate]
                                            DEFAULT SYSUTCDATETIME() FOR [CreatedDate];

                                        ALTER TABLE [auth].[ExternalLogins]
                                            ADD CONSTRAINT [FK_ExternalLogins_Users]
                                            FOREIGN KEY ([UserID])
                                            REFERENCES [auth].[Users]([UserID])
                                            ON DELETE CASCADE;

                                        ALTER TABLE [auth].[ExternalLogins]
                                            ADD CONSTRAINT [CK_ExternalLogins_Provider]
                                            CHECK
                                            (
                                                [Provider] IN
                                                (
                                                    N'Google',
                                                    N'Microsoft',
                                                    N'Facebook',
                                                    N'Apple',
                                                    N'GitHub'
                                                )
                                            );

                                        CREATE INDEX IX_ExternalLogins_UserID
                                            ON [auth].[ExternalLogins]([UserID]);

                                        CREATE INDEX IX_ExternalLogins_Email
                                            ON [auth].[ExternalLogins]([Email]);

                                    END
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureEmailVerificationTokensTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                   IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'EmailVerificationTokens'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[EmailVerificationTokens]
                                        (
                                            [TokenID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NOT NULL,
                                            [Token] NVARCHAR(500) NOT NULL,
                                            [EmailAddress] NVARCHAR(256) NOT NULL,
                                            [IssueDate] DATETIME2(3) NOT NULL,
                                            [ExpireDate] DATETIME2(3) NOT NULL,
                                            [IsUsed] BIT NOT NULL,
                                            [UsedDate] DATETIME2(3) NULL,
                                            [IPAddress] NVARCHAR(64) NULL,
                                            [IsActive] BIT NOT NULL,
                                            [IsDeleted] BIT NOT NULL,

                                            CONSTRAINT [PK_EmailVerificationTokens]
                                                PRIMARY KEY CLUSTERED ([TokenID])
                                        );

                                        ALTER TABLE [auth].[EmailVerificationTokens]
                                            ADD CONSTRAINT [DF_EVT_IssueDate]
                                            DEFAULT SYSUTCDATETIME() FOR [IssueDate];

                                        ALTER TABLE [auth].[EmailVerificationTokens]
                                            ADD CONSTRAINT [DF_EVT_IsUsed]
                                            DEFAULT 0 FOR [IsUsed];

                                        ALTER TABLE [auth].[EmailVerificationTokens]
                                            ADD CONSTRAINT [DF_EmailVerificationTokens_IsActive]
                                            DEFAULT 1 FOR [IsActive];

                                        ALTER TABLE [auth].[EmailVerificationTokens]
                                            ADD CONSTRAINT [DF_EmailVerificationTokens_IsDeleted]
                                            DEFAULT 0 FOR [IsDeleted];

                                        ALTER TABLE [auth].[EmailVerificationTokens]
                                            ADD CONSTRAINT [FK_EVT_Users]
                                            FOREIGN KEY ([UserID])
                                            REFERENCES [auth].[Users]([UserID])
                                            ON DELETE CASCADE;

                                        CREATE INDEX IX_EmailVerificationTokens_UserID
                                            ON [auth].[EmailVerificationTokens]([UserID]);

                                        CREATE INDEX IX_EmailVerificationTokens_EmailAddress
                                            ON [auth].[EmailVerificationTokens]([EmailAddress]);

                                        CREATE INDEX IX_EmailVerificationTokens_Token
                                            ON [auth].[EmailVerificationTokens]([Token]);

                                        CREATE INDEX IX_EmailVerificationTokens_ExpireDate
                                            ON [auth].[EmailVerificationTokens]([ExpireDate]);

                                    END
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<GeneralResponseDTO> EnsureUserMFATableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                   IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'UserMFA'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[UserMFA]
                                        (
                                            [UserMFAID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NOT NULL,
                                            [MFAType] NVARCHAR(30) NOT NULL,      -- Email | SMS | Authenticator
                                            [SecretKey] NVARCHAR(200) NULL,       -- TOTP Secret
                                            [IsEnabled] BIT NOT NULL,
                                            [CreatedDate] DATETIME2(3) NOT NULL,
                                            [ModifiedDate] DATETIME2(3) NULL,

                                            CONSTRAINT [PK_UserMFA]
                                                PRIMARY KEY CLUSTERED ([UserMFAID]),

                                            CONSTRAINT [UQ_UserMFA_User]
                                                UNIQUE ([UserID]),

                                            CONSTRAINT [FK_UserMFA_Users]
                                                FOREIGN KEY ([UserID])
                                                REFERENCES [auth].[Users]([UserID])
                                                ON DELETE CASCADE,

                                            CONSTRAINT [CK_UserMFA_Type]
                                                CHECK
                                                (
                                                    [MFAType] IN
                                                    (
                                                        N'Email',
                                                        N'SMS',
                                                        N'Authenticator'
                                                    )
                                                )
                                        );

                                        ALTER TABLE [auth].[UserMFA]
                                            ADD CONSTRAINT [DF_UserMFA_IsEnabled]
                                            DEFAULT 0 FOR [IsEnabled];

                                        ALTER TABLE [auth].[UserMFA]
                                            ADD CONSTRAINT [DF_UserMFA_CreatedDate]
                                            DEFAULT SYSUTCDATETIME() FOR [CreatedDate];

                                        CREATE INDEX IX_UserMFA_UserID
                                            ON [auth].[UserMFA]([UserID]);

                                        CREATE INDEX IX_UserMFA_MFAType
                                            ON [auth].[UserMFA]([MFAType]);

                                    END
                                    GO 
                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureMFAOTPsTableAsync()
        {
            try
            {
                const string sql = @"
                                 IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = N'auth')
                                        BEGIN
                                            EXEC('CREATE SCHEMA [auth] AUTHORIZATION [dbo];');
                                        END

                                IF NOT EXISTS
                                    (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s
                                            ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                          AND t.name = 'MFAOTPs'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[MFAOTPs]
                                        (
                                            [OTPID] INT IDENTITY(1,1) NOT NULL,
                                            [UserID] INT NOT NULL,
                                            [MFAToken] NVARCHAR(200) NOT NULL,
                                            [OTPHash] NVARCHAR(500) NOT NULL,
                                            [MFAType] NVARCHAR(30) NOT NULL,
                                            [Purpose] NVARCHAR(50) NOT NULL,
                                            [IssueDate] DATETIME2(3) NOT NULL,
                                            [ExpireDate] DATETIME2(3) NOT NULL,
                                            [IsUsed] BIT NOT NULL,
                                            [UsedDate] DATETIME2(3) NULL,
                                            [RetryCount] INT NOT NULL,
                                            [IPAddress] NVARCHAR(64) NULL,

                                            CONSTRAINT [PK_MFAOTPs]
                                                PRIMARY KEY CLUSTERED ([OTPID]),

                                            CONSTRAINT [FK_MFAOTPs_Users]
                                                FOREIGN KEY ([UserID])
                                                REFERENCES [auth].[Users]([UserID])
                                                ON DELETE CASCADE,

                                            CONSTRAINT [CK_MFAOTPs_MFAType]
                                                CHECK ([MFAType] IN (N'Email', N'SMS', N'Authenticator'))
                                        );

                                        ALTER TABLE [auth].[MFAOTPs]
                                            ADD CONSTRAINT [DF_MFAOTPs_Purpose]
                                            DEFAULT (N'Login') FOR [Purpose];

                                        ALTER TABLE [auth].[MFAOTPs]
                                            ADD CONSTRAINT [DF_MFAOTPs_IssueDate]
                                            DEFAULT (SYSUTCDATETIME()) FOR [IssueDate];

                                        ALTER TABLE [auth].[MFAOTPs]
                                            ADD CONSTRAINT [DF_MFAOTPs_IsUsed]
                                            DEFAULT (0) FOR [IsUsed];

                                        ALTER TABLE [auth].[MFAOTPs]
                                            ADD CONSTRAINT [DF_MFAOTPs_RetryCount]
                                            DEFAULT (0) FOR [RetryCount];

                                        CREATE UNIQUE NONCLUSTERED INDEX UX_MFAOTPs_MFAToken
                                            ON [auth].[MFAOTPs]([MFAToken]);

                                        CREATE NONCLUSTERED INDEX IX_MFAOTPs_User_Active
                                            ON [auth].[MFAOTPs]([UserID], [IsUsed], [ExpireDate]);

                                    END
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureCompaniesTableAsync()
        {
            try
            {
                const string sql = @"
                                  IF NOT EXISTS (
                                        SELECT 1
                                        FROM sys.schemas
                                        WHERE name = 'auth'
                                    )
                                    BEGIN
                                        EXEC('CREATE SCHEMA [auth]');
                                    END;

                                    IF NOT EXISTS (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s
                                            ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'Companies'
                                    )
                                    BEGIN
  
                                        CREATE TABLE [auth].[Companies] (
                                            [CompanyID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                                            [CompanyCode] NVARCHAR(50) NULL,
                                            [CompanyName] NVARCHAR(250) NULL,
                                            [CompanyAlias] NVARCHAR(250) NULL,
                                            [CompanyPicture] NVARCHAR(250) NULL,
                                            [CreatedDate] DATETIME NULL DEFAULT GETDATE(),
                                            [CreatedBy] INT NULL,
                                            [ModifiedDate] DATETIME NULL,
                                            [ModifiedBy] INT NULL,
                                            [ApprovedDate] DATETIME NULL,
                                            [ApprovedBy] INT NULL,
                                            [PostedDate] DATETIME NULL,
                                            [PostedBy] INT NULL,
                                            [DeletedDate] DATETIME NULL,
                                            [DeletedBy] INT NULL,
                                            [IsActive] BIT NULL DEFAULT 1,
                                            [IsApproved] BIT NULL DEFAULT 0,
                                            [IsPosted] BIT NULL DEFAULT 0,
                                            [IsDeleted] BIT NULL DEFAULT 0
                                        );

                                    END;

                                    -- CreatedBy
                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1
                                        FROM sys.foreign_keys
                                        WHERE name = 'FK_Companies_CreatedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[Companies]
                                        ADD CONSTRAINT [FK_Companies_CreatedBy]
                                        FOREIGN KEY ([CreatedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    -- ModifiedBy
                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1
                                        FROM sys.foreign_keys
                                        WHERE name = 'FK_Companies_ModifiedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[Companies]
                                        ADD CONSTRAINT [FK_Companies_ModifiedBy]
                                        FOREIGN KEY ([ModifiedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    -- ApprovedBy
                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1
                                        FROM sys.foreign_keys
                                        WHERE name = 'FK_Companies_ApprovedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[Companies]
                                        ADD CONSTRAINT [FK_Companies_ApprovedBy]
                                        FOREIGN KEY ([ApprovedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    -- PostedBy
                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1
                                        FROM sys.foreign_keys
                                        WHERE name = 'FK_Companies_PostedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[Companies]
                                        ADD CONSTRAINT [FK_Companies_PostedBy]
                                        FOREIGN KEY ([PostedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    -- DeletedBy
                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1
                                        FROM sys.foreign_keys
                                        WHERE name = 'FK_Companies_DeletedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[Companies]
                                        ADD CONSTRAINT [FK_Companies_DeletedBy]
                                        FOREIGN KEY ([DeletedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> EnsureUserCompaniesTableAsync()
        {
            try
            {
                const string sql = @"
                                   IF NOT EXISTS (
                                        SELECT 1
                                        FROM sys.schemas
                                        WHERE name = 'auth'
                                    )
                                    BEGIN
                                        EXEC('CREATE SCHEMA [auth]');
                                    END;

                                    IF NOT EXISTS (
                                        SELECT 1
                                        FROM sys.tables t
                                        INNER JOIN sys.schemas s
                                            ON t.schema_id = s.schema_id
                                        WHERE s.name = 'auth'
                                            AND t.name = 'UserCompanies'
                                    )
                                    BEGIN

                                        CREATE TABLE [auth].[UserCompanies]
                                        (
                                            [UserCompaniesID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,

                                            [UserCompaniesCode] NVARCHAR(50) NULL,
                                            [UserCompaniesName] NVARCHAR(250) NULL,
                                            [UserCompaniesAlias] NVARCHAR(250) NULL,

                                            [CompanyID] INT NULL,
                                            [UserID] INT NULL,

                                            [CreatedDate] DATETIME NULL DEFAULT(GETDATE()),
                                            [CreatedBy] INT NULL,

                                            [ModifiedDate] DATETIME NULL,
                                            [ModifiedBy] INT NULL,

                                            [ApprovedDate] DATETIME NULL,
                                            [ApprovedBy] INT NULL,

                                            [PostedDate] DATETIME NULL,
                                            [PostedBy] INT NULL,

                                            [DeletedDate] DATETIME NULL,
                                            [DeletedBy] INT NULL,

                                            [IsActive] BIT NULL DEFAULT(1),
                                            [IsApproved] BIT NULL DEFAULT(0),
                                            [IsPosted] BIT NULL DEFAULT(0),
                                            [IsDeleted] BIT NULL DEFAULT(0)
                                        );

                                    END;

                                    IF OBJECT_ID('[auth].[Companies]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_CompanyID'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_CompanyID]
                                        FOREIGN KEY ([CompanyID])
                                        REFERENCES [auth].[Companies]([CompanyID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_UserID'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_UserID]
                                        FOREIGN KEY ([UserID])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_CreatedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_CreatedBy]
                                        FOREIGN KEY ([CreatedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_ModifiedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_ModifiedBy]
                                        FOREIGN KEY ([ModifiedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_ApprovedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_ApprovedBy]
                                        FOREIGN KEY ([ApprovedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_PostedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_PostedBy]
                                        FOREIGN KEY ([PostedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;

                                    IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                    AND NOT EXISTS (
                                        SELECT 1 FROM sys.foreign_keys
                                        WHERE name = 'FK_UserCompanies_DeletedBy'
                                    )
                                    BEGIN
                                        ALTER TABLE [auth].[UserCompanies]
                                        ADD CONSTRAINT [FK_UserCompanies_DeletedBy]
                                        FOREIGN KEY ([DeletedBy])
                                        REFERENCES [auth].[Users]([UserID]);
                                    END;
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<GeneralResponseDTO> EnsureSystemEndpointsTableAsync()
        {
            try
            {
                const string sql = @"
                                    IF NOT EXISTS (
                                            SELECT 1
                                            FROM sys.schemas
                                            WHERE name = 'ses'
                                        )
                                        BEGIN
                                            EXEC('CREATE SCHEMA [ses]');
                                        END;

                                        IF NOT EXISTS (
                                            SELECT 1
                                            FROM sys.tables t
                                            INNER JOIN sys.schemas s
                                                ON t.schema_id = s.schema_id
                                            WHERE s.name = 'ses'
                                              AND t.name = 'SystemEndpoints'
                                        )
                                        BEGIN

                                            CREATE TABLE [ses].[SystemEndpoints]
                                            (
                                                [SystemEndpointID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

                                                [SystemName] NVARCHAR(200) NULL,
                                                [AreaName] NVARCHAR(200) NULL,
                                                [ControllerName] NVARCHAR(200) NULL,
                                                [TableName] NVARCHAR(200) NULL,
                                                [SchemaName] NVARCHAR(50) NULL,

                                                [CreatedDate] DATETIME NULL DEFAULT(GETDATE()),
                                                [CreatedBy] INT NULL,

                                                [ModifiedDate] DATETIME NULL,
                                                [ModifiedBy] INT NULL,

                                                [ApprovedDate] DATETIME NULL,
                                                [ApprovedBy] INT NULL,

                                                [PostedDate] DATETIME NULL,
                                                [PostedBy] INT NULL,

                                                [DeletedDate] DATETIME NULL,
                                                [DeletedBy] INT NULL,

                                                [IsActive] BIT NULL DEFAULT(1),
                                                [IsApproved] BIT NULL DEFAULT(0),
                                                [IsPosted] BIT NULL DEFAULT(0),
                                                [IsDeleted] BIT NULL DEFAULT(0)
                                            );

                                        END;

                                        IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                        AND NOT EXISTS (
                                            SELECT 1 FROM sys.foreign_keys
                                            WHERE name = 'FK_SystemEndpoints_CreatedBy'
                                        )
                                        BEGIN
                                            ALTER TABLE [ses].[SystemEndpoints]
                                            ADD CONSTRAINT [FK_SystemEndpoints_CreatedBy]
                                            FOREIGN KEY ([CreatedBy])
                                            REFERENCES [auth].[Users]([UserID]);
                                        END;

                                        IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                        AND NOT EXISTS (
                                            SELECT 1 FROM sys.foreign_keys
                                            WHERE name = 'FK_SystemEndpoints_ModifiedBy'
                                        )
                                        BEGIN
                                            ALTER TABLE [ses].[SystemEndpoints]
                                            ADD CONSTRAINT [FK_SystemEndpoints_ModifiedBy]
                                            FOREIGN KEY ([ModifiedBy])
                                            REFERENCES [auth].[Users]([UserID]);
                                        END;

                                        IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                        AND NOT EXISTS (
                                            SELECT 1 FROM sys.foreign_keys
                                            WHERE name = 'FK_SystemEndpoints_ApprovedBy'
                                        )
                                        BEGIN
                                            ALTER TABLE [ses].[SystemEndpoints]
                                            ADD CONSTRAINT [FK_SystemEndpoints_ApprovedBy]
                                            FOREIGN KEY ([ApprovedBy])
                                            REFERENCES [auth].[Users]([UserID]);
                                        END;

                                        IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                        AND NOT EXISTS (
                                            SELECT 1 FROM sys.foreign_keys
                                            WHERE name = 'FK_SystemEndpoints_PostedBy'
                                        )
                                        BEGIN
                                            ALTER TABLE [ses].[SystemEndpoints]
                                            ADD CONSTRAINT [FK_SystemEndpoints_PostedBy]
                                            FOREIGN KEY ([PostedBy])
                                            REFERENCES [auth].[Users]([UserID]);
                                        END;

                                        IF OBJECT_ID('[auth].[Users]', 'U') IS NOT NULL
                                        AND NOT EXISTS (
                                            SELECT 1 FROM sys.foreign_keys
                                            WHERE name = 'FK_SystemEndpoints_DeletedBy'
                                        )
                                        BEGIN
                                            ALTER TABLE [ses].[SystemEndpoints]
                                            ADD CONSTRAINT [FK_SystemEndpoints_DeletedBy]
                                            FOREIGN KEY ([DeletedBy])
                                            REFERENCES [auth].[Users]([UserID]);
                                        END;
                                    GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralResponseDTO> SeedDefaultCompanyAsync()
        {
            try
            {
                const string sql = @"
                                   IF NOT EXISTS
                                (
                                    SELECT 1
                                    FROM auth.Companies
                                    WHERE CompanyID = 1
                                )
                                BEGIN

                                    SET IDENTITY_INSERT auth.Companies ON;

                                    INSERT INTO auth.Companies
                                    (
                                        CompanyID,
                                        CompanyCode,
                                        CompanyName,
                                        CompanyAlias,
                                        IsActive,
                                        IsApproved,
                                        IsPosted,
                                        IsDeleted,
                                        CreatedDate
                                    )
                                    VALUES
                                    (
                                        1,
                                        'CO001',
                                        'Beanz Innovations',
                                        'Beanz Innovations',
                                        1,
                                        1,
                                        1,
                                        0,
                                        GETDATE()
                                    );

                                    SET IDENTITY_INSERT auth.Companies OFF;

                                END;
                                GO


                                set @Success=1
                                ";
                SqlParameter[] parameters =
               { 
                    //// output params: set Direction and (recommended) Size for nvarchar
                    new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
                };
                var cleaned = System.Text.RegularExpressions.Regex.Replace(sql, @"^\s*GO\s*$", "", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return await SQLDataAccessLayer.MultipleOutputBySqlAsync<GeneralResponseDTO>(cleaned, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
         
    }
}
