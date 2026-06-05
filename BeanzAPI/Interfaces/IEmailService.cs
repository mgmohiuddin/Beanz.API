namespace Beanz.API.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailVerificationAsync(string toEmail, string fullName, string verificationLink);
        Task SendMfaOtpAsync(string toEmail, string fullName, string otp);
        Task SendPasswordResetAsync(string toEmail, string fullName, string resetLink);
    }
}
