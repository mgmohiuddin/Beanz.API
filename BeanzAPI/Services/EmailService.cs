using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Beanz.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtp;
        private readonly string _emailDbConnectionString;

        public EmailService(IOptions<SmtpSettings> options, IConfiguration configuration)
        {
            _smtp = options.Value;
            _emailDbConnectionString = configuration.GetConnectionString("EmailDBConnectionString")
                ?? throw new InvalidOperationException("ConnectionStrings:EmailDBConnectionString is not configured.");
        }

        public Task SendEmailVerificationAsync(string toEmail, string fullName, string verificationLink)
        {
            var subject = "Verify your email";
            var body = $@"
            <h2>Hi {fullName},</h2>
            <p>Please verify your email by clicking the link below:</p>
            <p><a href=""{verificationLink}"">Verify Email</a></p>
            <p>This link expires soon.</p>";
            return QueueAsync(toEmail, subject, body, tranType: 1);
        }

        public Task SendMfaOtpAsync(string toEmail, string fullName, string otp)
        {
            var subject = "Your one-time verification code";
            var body = $@"<p>Hi {fullName},</p><p>Your verification code is: <b>{otp}</b></p>";
            return QueueAsync(toEmail, subject, body, tranType: 2);
        }

        public Task SendPasswordResetAsync(string toEmail, string fullName, string resetLink)
        {
            var subject = "Reset your password";
            var body = $@"<p>Hi {fullName},</p>
                     <p>Reset your password: <a href=""{resetLink}"">Reset Password</a></p>";
            return QueueAsync(toEmail, subject, body, tranType: 3);
        }

        // Inserts the notification row. MessageStatus = 0 (Pending) so the
        // notification worker can pick it up and dispatch via SMTP.
        private async Task QueueAsync(string to, string subject, string htmlBody, int tranType)
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
                MessageFrom = _smtp.FromAddress,
                MessageTo = to,
                MessageSubject = subject,
                MessageBody = htmlBody,
                MessageStatus = 0, // 0 = Pending, 1 = Sent, 2 = Failed
                SMTPServer = _smtp.Host,
                Port = _smtp.Port,
                DisplayName = _smtp.FromName,
                UniqueID = (long?)null,
                TranType = tranType,
                CompanyID = (long?)null,
            };

            using IDbConnection db = new SqlConnection(_emailDbConnectionString);
            await db.ExecuteAsync(sql, parameters);
        }
    }
}
