using Beanz.Models.AuthModule;
using System.Security.Claims;

namespace Beanz.API.Interfaces
{
    //public record JwtIssueResult(string AccessToken, string JwtId, DateTime ExpiresAt);

    public interface IJWTService
    {

        JwtIssueResult IssueAccessToken(User user, Guid sessionId, IEnumerable<string>? roles = null);
        string GenerateRefreshToken();
        ClaimsPrincipal? ValidateToken(string token, bool validateLifetime = true);
        string? GetJtiFromToken(string token);
        long? GetUserIdFromToken(string token);
    //}
    //    JwtIssueResult IssueAccessToken(User user, Guid sessionId, IEnumerable<string>? roles = null);
    //    string GenerateRefreshToken();
    }
    public class JwtIssueResult
    {
        public string Token { get; set; } = string.Empty;
        public string JwtId { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public Guid SessionId { get; set; }
    }
}
