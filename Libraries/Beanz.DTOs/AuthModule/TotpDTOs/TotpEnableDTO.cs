using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.TotpDTOs
{
    public class TotpEnableDTO
    {
        [Required, RegularExpression("^[0-9]{6}$", ErrorMessage = "Code must be 6 digits.")]
        public string Code { get; set; } = "";
    }
}
