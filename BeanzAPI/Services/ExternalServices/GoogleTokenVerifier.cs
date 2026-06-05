using Beanz.DTOs.AuthModule.ExternalDTOs;
using Google.Apis.Auth;   // NuGet: Google.Apis.Auth
namespace Beanz.API.Services.ExternalServices
{
    public interface IGoogleTokenVerifier
    {
        Task<GoogleProfileDTO> VerifyAsync(string idToken);
    }

    public class GoogleTokenVerifier : IGoogleTokenVerifier
    {
        private readonly string _clientId;
        public GoogleTokenVerifier(IConfiguration cfg)
            => _clientId = cfg["Google:ClientId"]!;

        public async Task<GoogleProfileDTO> VerifyAsync(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _clientId }
            };
            var p = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            return new GoogleProfileDTO
            {
                Sub = p.Subject,
                Email = p.Email,
                EmailVerified = p.EmailVerified,
                Name = p.Name,
                GivenName = p.GivenName,
                FamilyName = p.FamilyName,
                Picture = p.Picture,
                Locale = p.Locale
            };
        }
    }
}
