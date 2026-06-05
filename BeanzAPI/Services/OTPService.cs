using System.Security.Cryptography;
using System.Text;

namespace Beanz.API.Services
{
    public interface IOTPService
    {
        string GenerateNumericOtp(int length = 6);
        string HashOtp(string otp);
        bool VerifyOtp(string otp, string otpHash);

        // ---- TOTP (Authenticator apps) ----
        string GenerateBase32Secret(int byteLength = 20);
        string BuildOtpAuthUri(string issuer, string accountName, string base32Secret);
        bool VerifyTotp(string base32Secret, string code, int window = 1, int step = 30, int digits = 6);
    }

    public class OTPService : IOTPService
    {
        public string GenerateNumericOtp(int length = 6)
        {
            var max = (int)Math.Pow(10, length);
            var n = RandomNumberGenerator.GetInt32(0, max);
            return n.ToString().PadLeft(length, '0');
        }

        public string HashOtp(string otp) => BCrypt.Net.BCrypt.HashPassword(otp, workFactor: 10);
        public bool VerifyOtp(string otp, string otpHash) => BCrypt.Net.BCrypt.Verify(otp, otpHash);

        // ----- TOTP (RFC 6238) -----
        private static readonly char[] Base32Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();

        public string GenerateBase32Secret(int byteLength = 20)
        {
            var bytes = RandomNumberGenerator.GetBytes(byteLength);
            return ToBase32(bytes);
        }

        public string BuildOtpAuthUri(string issuer, string accountName, string base32Secret)
        {
            var label = Uri.EscapeDataString($"{issuer}:{accountName}");
            return $"otpauth://totp/{label}?secret={base32Secret}&issuer={Uri.EscapeDataString(issuer)}&algorithm=SHA1&digits=6&period=30";
        }

        public bool VerifyTotp(string base32Secret, string code, int window = 1, int step = 30, int digits = 6)
        {
            if (string.IsNullOrEmpty(code)) return false;
            var key = FromBase32(base32Secret);
            var unixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var counter = unixSeconds / step;
            for (var w = -window; w <= window; w++)
                if (string.Equals(ComputeHotp(key, counter + w, digits), code, StringComparison.Ordinal))
                    return true;
            return false;
        }

        private static string ComputeHotp(byte[] key, long counter, int digits)
        {
            var buffer = new byte[8];
            for (int i = 7; i >= 0; i--) { buffer[i] = (byte)(counter & 0xff); counter >>= 8; }
            using var hmac = new HMACSHA1(key);
            var hash = hmac.ComputeHash(buffer);
            var offset = hash[^1] & 0x0f;
            var binary = ((hash[offset] & 0x7f) << 24)
                       | ((hash[offset + 1] & 0xff) << 16)
                       | ((hash[offset + 2] & 0xff) << 8)
                       | (hash[offset + 3] & 0xff);
            var otp = binary % (int)Math.Pow(10, digits);
            return otp.ToString().PadLeft(digits, '0');
        }

        private static string ToBase32(byte[] data)
        {
            var sb = new StringBuilder();
            int buffer = 0, bitsLeft = 0;
            foreach (var b in data)
            {
                buffer = (buffer << 8) | b; bitsLeft += 8;
                while (bitsLeft >= 5) { sb.Append(Base32Alphabet[(buffer >> (bitsLeft - 5)) & 0x1f]); bitsLeft -= 5; }
            }
            if (bitsLeft > 0) sb.Append(Base32Alphabet[(buffer << (5 - bitsLeft)) & 0x1f]);
            return sb.ToString();
        }

        private static byte[] FromBase32(string s)
        {
            s = s.TrimEnd('=').ToUpperInvariant();
            var output = new byte[s.Length * 5 / 8];
            int buffer = 0, bitsLeft = 0, idx = 0;
            foreach (var c in s)
            {
                var val = Array.IndexOf(Base32Alphabet, c);
                if (val < 0) continue;
                buffer = (buffer << 5) | val; bitsLeft += 5;
                if (bitsLeft >= 8) { output[idx++] = (byte)((buffer >> (bitsLeft - 8)) & 0xff); bitsLeft -= 8; }
            }
            return output;
        }
    }
}
