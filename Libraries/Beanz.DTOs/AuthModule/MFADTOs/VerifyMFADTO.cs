using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.MFADTOs
{
    public class VerifyMFADTO
    {
        [Required] public string MFAToken { get; set; } = default!;
        [Required, StringLength(10, MinimumLength = 4)]
        public string OTP { get; set; } = default!;
    }
}
