using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.EmailDTOs
{
    public class VerifyEmailDTO
    {
        [Required]
        public string Token { get; set; } = default!;
    }
}
