using Beanz.DTOs.AuthModule.ExternalDTOs;
using System.Security.Cryptography;
using System.Text;

namespace Beanz.API.Services.ExternalServices
{
    public interface IFacebookTokenVerifier
    {
        Task<FacebookProfileDTO> VerifyAsync(string accessToken);
    }

    public class FacebookTokenVerifier : IFacebookTokenVerifier
    {
        private readonly HttpClient _http;
        private readonly string _appSecret;
        public FacebookTokenVerifier(HttpClient http, IConfiguration cfg)
        {
            _http = http;
            _appSecret = cfg["Facebook:AppSecret"]!;
        }

        public async Task<FacebookProfileDTO> VerifyAsync(string accessToken)
        {
            // appsecret_proof = HMAC-SHA256(access_token, app_secret)
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_appSecret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(accessToken));
            var proof = Convert.ToHexString(hash).ToLowerInvariant();

            var url = $"https://graph.facebook.com/v18.0/me?fields=id,name,email,picture" +
                      $"&access_token={accessToken}&appsecret_proof={proof}";
            var profile = await _http.GetFromJsonAsync<FacebookProfileDTO>(url)
                ?? throw new InvalidOperationException("Facebook token invalid");
            return profile;
        }
    }
}
