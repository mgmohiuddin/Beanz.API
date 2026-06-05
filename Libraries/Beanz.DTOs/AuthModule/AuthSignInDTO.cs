
using Beanz.DTOs.AuthModule.RequestResponse.Response;
using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.Auth
{
    public class AuthSignInDTO :AuthSignInResponseDTO
    {

        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        public string? DeviceInfo { get; set; }

        public string  Email { get; set; }  
        //public string  UserName { get; set; } 
        //public string Password { get; set; } 
        //public string PasswordHash { get; set; } 
        //public bool IsActive{ get; set; }
        public string googleSub { get; set; }

        public int? Type { get; set; }





    }
}
