using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class MicrosoftSignInDTO
    {
        public string IdToken { get; set; } = default!;
    }

    public class MicrosoftProfileDTO
    {
        public string Sub { get; set; } = default!;     // 'oid' or 'sub'
        public string Email { get; set; } = default!;
        public string? Name { get; set; }
        public string? PreferredUsername { get; set; }
        public string? TenantId { get; set; }
    }
}
