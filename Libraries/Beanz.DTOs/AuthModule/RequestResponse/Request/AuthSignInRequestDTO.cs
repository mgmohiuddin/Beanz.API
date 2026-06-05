using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Request
{
    public class AuthSignInRequestDTO
    {


        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        public string? DeviceInfo { get; set; }

        public int? LanguageID { get; set; }


    }
}
