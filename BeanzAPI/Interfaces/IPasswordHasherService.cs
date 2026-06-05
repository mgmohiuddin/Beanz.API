namespace Beanz.API.Interfaces
{
    public interface IPasswordHasherService
    {
        // Username is folded into the hash input so a stolen/swapped hash
        // from another user's row will fail verification.
        string Hash(string userName, string password);
        bool Verify(string userName, string password, string hash);

        // For non-password values (e.g. OTPs) where there is no username binding.
        string HashRaw(string value);
        bool VerifyRaw(string value, string hash);
    }
}
