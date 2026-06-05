using Beanz.Models.AuthModule;
using Beanz.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule
{
    public interface IEmailVerificationTokenService
    {
        Task SendEmailVerificationAsync(EmailNotification emailNotification,string VarificationLink);
        //Task SendMfaOtpAsync(string toEmail, string fullName, string otp);
        //Task SendPasswordResetAsync(string toEmail, string fullName, string resetLink);
    }
}
