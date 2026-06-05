using Beanz.DTOs.AuthModule.ExternalDTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Beanz.API.Services.ExternalServices
{
    
    public interface ITwitterTokenVerifier
    {
        Task<TwitterUser> ExchangeAndFetchAsync(string code, string codeVerifier);
    }

    public class TwitterTokenVerifier : ITwitterTokenVerifier
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _cfg;
        public TwitterTokenVerifier(HttpClient http, IConfiguration cfg)
        { _http = http; _cfg = cfg; }

        public async Task<TwitterUser> ExchangeAndFetchAsync(string code, string codeVerifier)
        {
            var clientId = _cfg["Twitter:ClientId"]!;
            var clientSecret = _cfg["Twitter:ClientSecret"]!;
            var redirect = _cfg["Twitter:RedirectUri"]!;

            var req = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/2/oauth2/token");
            var basic = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", basic);
            req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["code"] = code,
                ["redirect_uri"] = redirect,
                ["code_verifier"] = codeVerifier,
                ["client_id"] = clientId
            });
            var res = await _http.SendAsync(req);
            var tok = await res.Content.ReadFromJsonAsync<TwitterTokenResponse>()
                ?? throw new InvalidOperationException("Twitter token exchange failed");

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tok.Access_token);
            var me = await _http.GetFromJsonAsync<TwitterMeResponse>(
                "https://api.twitter.com/2/users/me?user.fields=profile_image_url");
            return me!.Data;
        }
    }
}
