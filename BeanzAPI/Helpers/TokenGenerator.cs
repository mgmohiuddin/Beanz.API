using System.Security.Cryptography;

namespace Beanz.API.Helpers
{
    public static class TokenGenerator
    {
        public static string CreateSecureToken(int byteLength = 48)
        {
            var bytes = RandomNumberGenerator.GetBytes(byteLength);
            return Convert.ToBase64String(bytes)
                .Replace("+", "-").Replace("/", "_").TrimEnd('=');
        }
    }
}
