using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.MFADTOs
{
    public class MFAChallengeDTO
    {
        public bool MfaRequired { get; set; } = true;
        public string MFAToken { get; set; } = default!;
        public string MFAType { get; set; } = default!;   // Email | SMS | Authenticator
        public string? MaskedDestination { get; set; }    // e.g. "j***@example.com" or "***1234"
    }
}
