using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Security.Cryptography;
using OtpNet;
using QRCoder;
using System;
using System.Security.Cryptography;

namespace Beanz.API.Services
{
    public interface ITotpService
    {
        string GenerateSecretBase32();
        string BuildOtpAuthUrl(string secretBase32, string accountEmail, string issuer);
        string BuildQrPngBase64(string otpAuthUrl);
        bool VerifyCode(string secretBase32, string code);
    }
    public class TotpService : ITotpService
    {
        private const string Issuer = "MyApp"; // shown in Authenticator app

        // 20 random bytes = 160-bit secret (RFC 4226 recommendation)
        public string GenerateSecretBase32()
        {
            var bytes = new byte[20];
            RandomNumberGenerator.Fill(bytes);
            return Base32Encoding.ToString(bytes).TrimEnd('=');
        }

        // otpauth://totp/Issuer:email?secret=XXXX&issuer=Issuer&algorithm=SHA1&digits=6&period=30
        public string BuildOtpAuthUrl(string secretBase32, string accountEmail, string issuer)
        {
            issuer = string.IsNullOrWhiteSpace(issuer) ? Issuer : issuer;
            var label = Uri.EscapeDataString($"{issuer}:{accountEmail}");
            return $"otpauth://totp/{label}" +
                   $"?secret={secretBase32}" +
                   $"&issuer={Uri.EscapeDataString(issuer)}" +
                   $"&algorithm=SHA1&digits=6&period=30";
        }

        public string BuildQrPngBase64(string otpAuthUrl)
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode(otpAuthUrl, QRCodeGenerator.ECCLevel.Q);
            var png = new PngByteQRCode(data).GetGraphic(20);
            return Convert.ToBase64String(png);
        }

        // The CORE: verify on-the-fly using SecretKey + current UTC time.
        // Nothing is stored per-OTP — that's why auth.MFAOTPs excludes Authenticator.
        public bool VerifyCode(string secretBase32, string code)
        {
            if (string.IsNullOrWhiteSpace(secretBase32) || string.IsNullOrWhiteSpace(code))
                return false;

            var secretBytes = Base32Encoding.ToBytes(secretBase32);
            var totp = new Totp(secretBytes, step: 30, mode: OtpHashMode.Sha1, totpSize: 6);

            // VerificationWindow(1,1) = allow ±30s clock drift between server and phone.
            return totp.VerifyTotp(code, out _, new VerificationWindow(previous: 1, future: 1));
        }
    }
}
