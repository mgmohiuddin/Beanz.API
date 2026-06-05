using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class GoogleSignInDTO
    {
        public string IdToken { get; set; } = default!;
    }
    // Parsed Google ID Token payload (subset)
    public class GoogleProfileDTO
    {
        public string Sub { get; set; } = default!;   // unique Google user id
        public string Email { get; set; } = default!;
        public bool EmailVerified { get; set; }
        public string? Name { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string? Picture { get; set; }
        public string? Locale { get; set; }
    }
}
