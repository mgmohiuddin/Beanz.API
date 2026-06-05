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
    public class AuthSignOutDTO  : AuthSignInResponseDTO
    {
        public long? CompanyID { get; set; }
        [Required]
        public int? UserID { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
