using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beanz.DTOs.Common;

namespace Beanz.DTOs.Auth
{

    public class ForgetPasswordRequestDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        public int LanguageID { get; set; } = 1;
    }

    // DTOs/Auth/ForgetPasswordRequestResponseDTO.cs
    public class ForgetPasswordRequestResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? UserID { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }


     
   
}
