using Beanz.DTOs.AuthModule.ExternalDTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Beanz.API.Services.ExternalServices
{
    public interface ILinkedInTokenVerifier
    {
        Task<LinkedInProfileDTO> ExchangeAndFetchAsync(string code);
    }

    public class LinkedInTokenVerifier : ILinkedInTokenVerifier
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _cfg;
        public LinkedInTokenVerifier(HttpClient http, IConfiguration cfg)
        { _http = http; _cfg = cfg; }

        public async Task<LinkedInProfileDTO> ExchangeAndFetchAsync(string code)
        {
            var form = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["code"] = code,
                ["redirect_uri"] = _cfg["LinkedIn:RedirectUri"]!,
                ["client_id"] = _cfg["LinkedIn:ClientId"]!,
                ["client_secret"] = _cfg["LinkedIn:ClientSecret"]!
            });
            var tokRes = await _http.PostAsync("https://www.linkedin.com/oauth/v2/accessToken", form);
            var tok = await tokRes.Content.ReadFromJsonAsync<LinkedInTokenResponse>()
                ?? throw new InvalidOperationException("LinkedIn token exchange failed");

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tok.Access_token);
            var profile = await _http.GetFromJsonAsync<LinkedInProfileDTO>(
                "https://api.linkedin.com/v2/userinfo")
                ?? throw new InvalidOperationException("LinkedIn profile fetch failed");
            return profile;
        }
    }
}
