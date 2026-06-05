using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.TotpDTOs
{
    public class TotpSetupResponseDTO
    {
        public string SecretBase32 { get; set; } = "";     // show as manual key
        public string OtpAuthUrl { get; set; } = "";     // encode into QR
        public string QrCodePngBase64 { get; set; } = "";  // ready-to-render <img src="data:image/png;base64,...">
    }

}
