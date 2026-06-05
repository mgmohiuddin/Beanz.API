using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    // Facebook — returns an access_token from the JS SDK
    public class ExternalAccessTokenDTO
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;
    }
}
