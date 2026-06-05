using Beanz.DTOs.AuthModule.ExternalDTOs;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Beanz.API.Services.ExternalServices
{
    public interface IAppleTokenVerifier
    {
        Task<AppleProfileDTO> VerifyAsync(string idToken);
    }

    public class AppleTokenVerifier : IAppleTokenVerifier
    {
        private readonly string _clientId;
        private readonly ConfigurationManager<OpenIdConnectConfiguration> _cfg;

        public AppleTokenVerifier(IConfiguration cfg)
        {
            _clientId = cfg["Apple:ClientId"]!;  // Services ID
            _cfg = new ConfigurationManager<OpenIdConnectConfiguration>(
                "https://appleid.apple.com/.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever());
        }

        public async Task<AppleProfileDTO> VerifyAsync(string idToken)
        {
            var oidc = await _cfg.GetConfigurationAsync(default);
            var handler = new JwtSecurityTokenHandler();
            var parms = new TokenValidationParameters
            {
                ValidIssuer = "https://appleid.apple.com",
                ValidAudience = _clientId,
                IssuerSigningKeys = oidc.SigningKeys,
                ValidateLifetime = true
            };
            var principal = handler.ValidateToken(idToken, parms, out _);
            string C(string k) => principal.FindFirst(k)?.Value ?? "";
            var email = C("email");
            return new AppleProfileDTO
            {
                Sub = C("sub"),
                Email = email,
                EmailVerified = C("email_verified") == "true",
                IsPrivateRelay = email.EndsWith("@privaterelay.appleid.com", StringComparison.OrdinalIgnoreCase)
            };
        }
    }
}
