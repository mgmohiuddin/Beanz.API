using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.Auth
{
    public class AuthChangePasswordDTO  
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$",
           ErrorMessage = "Password must contain upper, lower, digit and special character.")]
        public string NewPassword { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$",
           ErrorMessage = "Password must contain upper, lower, digit and special character.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public int? CompanyID { get; set; }
        public int UserID { get; set; }
    }
}
