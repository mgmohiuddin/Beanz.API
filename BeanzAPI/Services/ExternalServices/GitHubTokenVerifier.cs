using Beanz.DTOs.AuthModule.ExternalDTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Beanz.API.Services.ExternalServices
{
    public interface IGitHubTokenVerifier
    {
        Task<GitHubProfileDTO> ExchangeAndFetchAsync(string code);
    }

    public class GitHubTokenVerifier : IGitHubTokenVerifier
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _cfg;
        public GitHubTokenVerifier(HttpClient http, IConfiguration cfg)
        { _http = http; _cfg = cfg; }

        public async Task<GitHubProfileDTO> ExchangeAndFetchAsync(string code)
        {
            // 1. Exchange code -> access_token
            var tokReq = new HttpRequestMessage(HttpMethod.Post, "https://github.com/login/oauth/access_token");
            tokReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            tokReq.Content = JsonContent.Create(new
            {
                client_id = _cfg["GitHub:ClientId"],
                client_secret = _cfg["GitHub:ClientSecret"],
                code,
                redirect_uri = _cfg["GitHub:RedirectUri"]
            });
            var tokRes = await _http.SendAsync(tokReq);
            var tok = await tokRes.Content.ReadFromJsonAsync<GitHubTokenResponse>()
                ?? throw new InvalidOperationException("GitHub token exchange failed");

            // 2. Fetch profile
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tok.Access_token);
            var profile = await _http.GetFromJsonAsync<GitHubProfileDTO>("https://api.github.com/user")
                ?? throw new InvalidOperationException("GitHub profile fetch failed");

            // 3. If email hidden, fetch via /user/emails and pick primary+verified
            if (string.IsNullOrEmpty(profile.Email))
            {
                var emails = await _http.GetFromJsonAsync<List<GitHubEmail>>("https://api.github.com/user/emails");
                profile.Email = emails?.FirstOrDefault(e => e.Primary && e.Verified)?.Email;
            }
            return profile;
        }
    }
}
