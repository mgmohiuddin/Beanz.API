using Beanz.API.Interfaces;

namespace Beanz.API.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        // Requires NuGet: BCrypt.Net-Next

        // Normalize username so casing/whitespace differences never break login.
        private static string Compose(string userName, string password)
            => $"{(userName ?? string.Empty).Trim().ToLowerInvariant()}:{password}";

        public string Hash(string userName, string password)
            => BCrypt.Net.BCrypt.HashPassword(Compose(userName, password), workFactor: 12);

        public bool Verify(string userName, string password, string hash)
            => BCrypt.Net.BCrypt.Verify(Compose(userName, password), hash);

        public string HashRaw(string value)
            => BCrypt.Net.BCrypt.HashPassword(value, workFactor: 10);

        public bool VerifyRaw(string value, string hash)
            => BCrypt.Net.BCrypt.Verify(value, hash);
    }
}
