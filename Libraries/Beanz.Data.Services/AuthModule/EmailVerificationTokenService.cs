using AutoMapper;
using Beanz.Core.AuthModule;
using Beanz.Models.AuthModule;
using Beanz.Models.Common;
using Beanz.Utilities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Data.Services.AuthModule
{
    public class EmailVerificationTokenService : IEmailVerificationTokenService
    { 
        private readonly string _emailDbConnectionString;
        private readonly IMapper _mapper;
        public EmailVerificationTokenService(IConfiguration configuration)
        {
            //_mapper = mapper;
           _emailDbConnectionString = configuration.GetConnectionString("EmailDB")
           ?? throw new InvalidOperationException("ConnectionStrings:EmailDB is not configured.");
        }

        public Task SendEmailVerificationAsync(EmailNotification emailVerificationToken,string VarificationLink)
        {
            var subject = "Verify your email";
            var body = $@"
            <h2>Hi {emailVerificationToken.DisplayName},</h2>
            <p>Please verify your email by clicking the link below:</p>
            <p><a href=""{VarificationLink}"">Verify Email</a></p>
            <p>This link expires soon.</p>";
            return QueueAsync(emailVerificationToken);
        }

        //public Task SendMfaOtpAsync(string toEmail, string fullName, string otp)
        //{
        //    var subject = "Your one-time verification code";
        //    var body = $@"<p>Hi {fullName},</p><p>Your verification code is: <b>{otp}</b></p>";
        //    return QueueAsync(toEmail, subject, body, tranType: 2);
        //}

        //public Task SendPasswordResetAsync(string toEmail, string fullName, string resetLink)
        //{
        //    var subject = "Reset your password";
        //    var body = $@"<p>Hi {fullName},</p>
        //             <p>Reset your password: <a href=""{resetLink}"">Reset Password</a></p>";
        //    return QueueAsync(toEmail, subject, body, tranType: 3);
        //}

        //// Inserts the notification row. MessageStatus = 0 (Pending) so the
        //// notification worker can pick it up and dispatch via SMTP.
        private async Task QueueAsync(EmailNotification emailVerificationToken)
        {
            const string sql = @"
                    INSERT INTO dbo.EmailNotificationTbl
                        (MessageFrom, MessageTo, MessageCc, MessageBcc, MessageSubject, MessageBody,
                         MessageStatus, SMTPServer, Port, DisplayName, FileAttachments, ErrorDesc,
                         UniqueID, TranType, CompanyID)
                    VALUES
                        (@MessageFrom, @MessageTo, NULL, NULL, @MessageSubject, @MessageBody,
                         @MessageStatus, @SMTPServer, @Port, @DisplayName, NULL, NULL,
                         @UniqueID, @TranType, @CompanyID);";

            var parameters = new
            {
                emailVerificationToken.MessageFrom,
                emailVerificationToken.MessageTo,
                emailVerificationToken.MessageSubject,
                emailVerificationToken.MessageBody,
                MessageStatus = 0, // 0 = Pending, 1 = Sent, 2 = Failed
                emailVerificationToken.SMTPServer,
                emailVerificationToken.Port,
                emailVerificationToken.DisplayName,
                UniqueID = (long?)null,
                emailVerificationToken.TranType,
                CompanyID = (long?)null,
            };

            using IDbConnection db = new SqlConnection(_emailDbConnectionString);
            await db.ExecuteAsync(sql, parameters);
        }
    }
}
