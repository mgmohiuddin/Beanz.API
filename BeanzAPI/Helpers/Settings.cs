namespace Beanz.API.Helpers
{
    public class JwtSettings
    {
        public string Secret { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int AccessTokenMinutes { get; set; } = 15;
        public int RefreshTokenDays { get; set; } = 7;
    }

    public class SmtpSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; } = 587;
        public bool EnableSsl { get; set; } = true;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FromAddress { get; set; } = default!;
        public string FromName { get; set; } = "No Reply";
    }

    public class AuthSettings
    {
        public string WebAppBaseUrl { get; set; } = "https://localhost:5173";
        public int EmailVerificationTokenExpiryHours { get; set; } = 24;
        public int MaxFailedLoginAttempts { get; set; } = 5;
        public int LockoutMinutes { get; set; } = 15;
        public int OtpExpiryMinutes { get; set; } = 5;
        public int OtpMaxRetries { get; set; } = 3;
    }
}
