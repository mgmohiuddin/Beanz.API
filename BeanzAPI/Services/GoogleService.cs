using Google.Apis.Auth;
using System.Configuration;

namespace BeanzAPI.Services
{
    public class GoogleService
    { 
        
        public class GoogleTokenResult
        {
            public bool Success { get; set; }
            public GoogleJsonWebSignature.Payload? Payload { get; set; }
            public string? Message { get; set; }
            public string? Type { get; set; }
        }

        public async Task<GoogleTokenResult> VerifyGoogleTokenAsync(string token, IConfiguration configuration)
        {
            try
            {
                //  _GoogelString = Configuration["Google:ClientId"]
                //?? throw new InvalidOperationException("ConnectionStrings:EmailDBConnectionString is not configured.");
                
                var clientId = configuration["Google:ClientId"];

                var payload = await GoogleJsonWebSignature.ValidateAsync(
                    token,
                    new GoogleJsonWebSignature.ValidationSettings
                    {
                        Audience = new[] { clientId }
                    });

                return new GoogleTokenResult
                {
                    Success = true,
                    Payload = payload
                };
            }
            catch (Exception ex)
            {
                return new GoogleTokenResult
                {
                    Success = false,
                    Message = ex.Message,
                    Type = ex.GetType().Name
                };
            }
        }
    }
}
