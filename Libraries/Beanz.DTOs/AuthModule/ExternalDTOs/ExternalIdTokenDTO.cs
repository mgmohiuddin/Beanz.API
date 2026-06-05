using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class ExternalIdTokenDTO
    {
        [Required]
        public string IdToken { get; set; } = string.Empty;
    }
}
