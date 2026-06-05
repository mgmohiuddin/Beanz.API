namespace Beanz.API.Services
{
    public interface ISmsService
    {
        Task SendOtpAsync(string mobileNumber, string otp);
    }

    public class SmsService : ISmsService
    {
        private readonly ILogger<SmsService> _logger;
        public SmsService(ILogger<SmsService> logger) => _logger = logger;

        public Task SendOtpAsync(string mobileNumber, string otp)
        {
            _logger.LogInformation("SMS OTP to {Mobile}: {Otp}", mobileNumber, otp);
            return Task.CompletedTask;
        }
    }
}
