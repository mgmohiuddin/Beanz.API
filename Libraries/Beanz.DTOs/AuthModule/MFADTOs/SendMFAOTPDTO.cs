using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.MFADTOs
{
    public class SendMFAOTPDTO
    {
        [Required] public string MFAToken { get; set; } = default!;
    }
}
