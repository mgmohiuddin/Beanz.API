using Beanz.DTOs.AuthModule.ExternalDTOs;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Beanz.API.Services.ExternalServices
{
    public interface IMicrosoftTokenVerifier
    {
        Task<MicrosoftProfileDTO> VerifyAsync(string idToken);
    }
    public class MicrosoftTokenVerifier : IMicrosoftTokenVerifier
    {
        private readonly string _clientId;
        private readonly ConfigurationManager<OpenIdConnectConfiguration> _cfg;

        public MicrosoftTokenVerifier(IConfiguration cfg)
        {
            _clientId = cfg["Microsoft:ClientId"]!;
            var tenant = cfg["Microsoft:TenantId"] ?? "common";
            _cfg = new ConfigurationManager<OpenIdConnectConfiguration>(
                $"https://login.microsoftonline.com/{tenant}/v2.0/.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever());
        }

        public async Task<MicrosoftProfileDTO> VerifyAsync(string idToken)
        {
            var oidc = await _cfg.GetConfigurationAsync(default);
            var handler = new JwtSecurityTokenHandler();
            var parms = new TokenValidationParameters
            {
                ValidAudience = _clientId,
                ValidateIssuer = false, // multi-tenant: validate issuer manually if needed
                IssuerSigningKeys = oidc.SigningKeys,
                ValidateLifetime = true
            };
            var principal = handler.ValidateToken(idToken, parms, out _);
            string C(string k) => principal.FindFirst(k)?.Value ?? "";
            return new MicrosoftProfileDTO
            {
                Sub = C("oid").Length > 0 ? C("oid") : C("sub"),
                Email = C("email").Length > 0 ? C("email") : C("preferred_username"),
                Name = C("name"),
                PreferredUsername = C("preferred_username"),
                TenantId = C("tid")
            };
        }
    }
}
