using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class LinkedInCallbackDTO
    {
        public string Code { get; set; } = default!;
        public string? State { get; set; }
    }

    public class LinkedInTokenResponse
    {
        public string Access_token { get; set; } = default!;
        public int Expires_in { get; set; }
        public string? Id_token { get; set; }
        public string? Scope { get; set; }
    }

    // Returned by /v2/userinfo (OIDC)
    public class LinkedInProfileDTO
    {
        public string Sub { get; set; } = default!;
        public string? Email { get; set; }
        public bool Email_verified { get; set; }
        public string? Name { get; set; }
        public string? Given_name { get; set; }
        public string? Family_name { get; set; }
        public string? Picture { get; set; }
        public string? Locale { get; set; }
    }
}
