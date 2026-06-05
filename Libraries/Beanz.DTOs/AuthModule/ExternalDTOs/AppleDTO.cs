using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class AppleSignInDTO
    {
        public string IdToken { get; set; } = default!;
        public string? UserJson { get; set; }   // only on first login: { "name": { "firstName":"", "lastName":"" }, "email":"" }
    }

    public class AppleProfileDTO
    {
        public string Sub { get; set; } = default!;
        public string? Email { get; set; }
        public bool EmailVerified { get; set; }
        public bool IsPrivateRelay { get; set; }
        public string? Name { get; set; }
    }
}
