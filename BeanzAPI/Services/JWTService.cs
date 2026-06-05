using Beanz.Models.AuthModule;
using Beanz.API.Helpers;
using Beanz.API.Interfaces;
using Beanz.API.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Beanz.API.Services
{
    public class JWTService : IJWTService
    {

        private readonly JwtSettings _settings;
        private readonly SymmetricSecurityKey _signingKey;
        private readonly IConfiguration _config;
        public JWTService(IOptions<JwtSettings> settings, IConfiguration config)
        {
            _settings = settings.Value;

            if (string.IsNullOrWhiteSpace(_settings.Secret))
                throw new InvalidOperationException("JwtSettings:Secret is missing.");
            if (Encoding.UTF8.GetByteCount(_settings.Secret) < 32)
                throw new InvalidOperationException("JwtSettings:Secret must be at least 32 bytes for HS256.");

            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            _config = config;
        }

        //public JwtIssueResult IssueAccessToken(User user, Guid sessionId, IEnumerable<string>? roles = null)
        //{
        //    var jwtId = Guid.NewGuid().ToString("N");
        //    var now = DateTime.UtcNow;
        //    var expires = now.AddMinutes(_settings.AccessTokenMinutes);

        //    var claims = new List<Claim>
        //    {
        //        new(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
        //        new(JwtRegisteredClaimNames.Jti, jwtId),
        //        new(JwtRegisteredClaimNames.Iat,
        //            new DateTimeOffset(now).ToUnixTimeSeconds().ToString(),
        //            ClaimValueTypes.Integer64),
        //        new(ClaimTypes.NameIdentifier, user.UserID.ToString()),
        //        new(ClaimTypes.Name, user.UserName ?? string.Empty),
        //        new(ClaimTypes.Email, user.EmailAddress ?? string.Empty),
        //        new("sessionId", sessionId.ToString()),
        //    };

        //    if (roles != null)
        //    {
        //        foreach (var role in roles.Where(r => !string.IsNullOrWhiteSpace(r)))
        //            claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: _settings.Issuer,
        //        audience: _settings.Audience,
        //        claims: claims,
        //        notBefore: now,
        //        expires: expires,
        //        signingCredentials: creds);

        //    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        //    return new JwtIssueResult
        //    {
        //        Token = tokenString,
        //        JwtId = jwtId,
        //        ExpiresAt = expires,
        //        SessionId = sessionId,
        //    };
        //}


        public JwtIssueResult IssueAccessToken(User user,Guid sessionId, IEnumerable<string>? roles = null)
        {
            var jwtId = Guid.NewGuid().ToString("N");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuedAt = DateTime.Now;   // Issue time (iat)
            var expiration = issuedAt.AddDays(7); // Expiration time (exp)

            var claims = new[]
            {

                //new Claim(ClaimTypes.Email,user.Email ?? string.Empty ),
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString() ),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(issuedAt).ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64)
                //new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(20))
            };

            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims: claims,
                notBefore: issuedAt, // Token is valid from this time
                expires: expiration, // Correct expiration time
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtIssueResult
            {
                AccessToken = tokenString,
                Token = tokenString,
                JwtId = jwtId,
                ExpiresAt = expiration,
                SessionId = sessionId,
            };
        }
        public string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }


        public ClaimsPrincipal? ValidateToken(string token, bool validateLifetime = true)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _settings.Issuer,
                ValidateAudience = true,
                ValidAudience = _settings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                ValidateLifetime = validateLifetime,
                ClockSkew = TimeSpan.FromMinutes(1),
            };

            try
            {
                return handler.ValidateToken(token, parameters, out _);
            }
            catch
            {
                return null;
            }
        }

        public string? GetJtiFromToken(string token)
            => ReadClaim(token, JwtRegisteredClaimNames.Jti);

        public long? GetUserIdFromToken(string token)
        {
            var sub = ReadClaim(token, JwtRegisteredClaimNames.Sub);
            return long.TryParse(sub, out var id) ? id : null;
        }

        private static string? ReadClaim(string token, string claimType)
        {
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                return jwt.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
            }
            catch { return null; }
        }


        //private readonly JwtSettings _settings;

        //public JWTService(IOptions<JwtSettings> options) => _settings = options.Value;

        //public JwtIssueResult IssueAccessToken(User user, Guid sessionId, IEnumerable<string>? roles = null)
        //{
        //    var jwtId = Guid.NewGuid().ToString("N");
        //    var expires = DateTime.UtcNow.AddMinutes(_settings.AccessTokenMinutes);

        //    var claims = new List<Claim>
        //{
        //    new(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
        //    new(JwtRegisteredClaimNames.Jti, jwtId),
        //    new(ClaimTypes.NameIdentifier, user.UserID.ToString()),
        //    new(ClaimTypes.Name, user.UserName),
        //    new(ClaimTypes.Email, user.EmailAddress),
        //    new("session_id", sessionId.ToString()),
        //};

        //    if (roles is not null)
        //        foreach (var r in roles) claims.Add(new Claim(ClaimTypes.Role, r));

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: _settings.Issuer,
        //        audience: _settings.Audience,
        //        claims: claims,
        //        notBefore: DateTime.UtcNow,
        //        expires: expires,
        //        signingCredentials: creds);

        //    var encoded = new JwtSecurityTokenHandler().WriteToken(token);
        //    return new JwtIssueResult(encoded, jwtId, expires);
        //}


        //public string GenerateRefreshToken()
        //{
        //    var bytes = RandomNumberGenerator.GetBytes(64);
        //    return Convert.ToBase64String(bytes);
        //}

        ////private readonly IConfiguration _config;
        ////public JWTService(IConfiguration config) { _config = config; }

        ////public async Task<TokenResponse> GenerateTokenAsync(string username)
        ////{
        ////    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        ////    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        ////    var expiration = DateTime.UtcNow.AddHours(1);

        ////    var claims = new[] {
        ////    new Claim(ClaimTypes.Name, username),
        ////    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ////};

        ////    var token = new JwtSecurityToken(
        ////        issuer: _config["Jwt:Issuer"],
        ////        audience: _config["Jwt:Audience"],
        ////        claims: claims,
        ////        expires: DateTime.UtcNow.AddHours(1),
        ////        signingCredentials: credentials
        ////    );
        ////    return await Task.FromResult(new TokenResponse
        ////    {
        ////        Token = new JwtSecurityTokenHandler().WriteToken(token),
        ////        Expiration = expiration
        ////    });
        ////    //return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        ////}
    }
}
