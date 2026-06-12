using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.Auth
{


    public class ResetPasswordVerifyDTO
    {
        
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
        
    }
    public class ResetPasswordRequestDTO
    {
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
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
        public string NewPasswordSalt {  get; set; } = string.Empty;
        public int LanguageID { get; set; } = 1;
        public int? UserID { get; set; }
    }
    // DTOs/Auth/ResetPasswordResponseDTO.cs
    public class ResetPasswordResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
    }

    
    // DTOs/Auth/SavePasswordResetTokenDTO.cs
    public class SavePasswordResetTokenDTO
    {
        public int? UserID { get; set; }
        public string EmailAddress { get; set; }
        public string TokenHash { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int? LanguageID { get; set; } = 1;
    }

   
   
   
}
