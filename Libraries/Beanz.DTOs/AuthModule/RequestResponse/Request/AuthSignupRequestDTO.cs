using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Request
{
    public class AuthSignupRequestDTO
    {
     
        
            [Required, StringLength(100, MinimumLength = 3)]
            public string UserName { get; set; } = default!;

            [Required, StringLength(200, MinimumLength = 2)]
            public string FullName { get; set; } = default!;

            [Required, EmailAddress, StringLength(256)]
            public string EmailAddress { get; set; } = default!;

            [Required]
            [StringLength(100, MinimumLength = 8)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$",
                ErrorMessage = "Password must contain upper, lower, digit and special character.")]
            public string Password { get; set; } = default!;

            [Required, Compare(nameof(Password))]
            public string ConfirmPassword { get; set; } = default!;

            [StringLength(20)]
            public string MobileNumber { get; set; }

            [StringLength(10)]
            public string CountryCode { get; set; }

            [Url, StringLength(1000)]
            public string ProfilePictureUrl { get; set; }

            [Url, StringLength(1000)]
            public string AvatarUrl { get; set; }

            public int? LanguageID { get; set; }
            public string googleSub { get; set; }

            public int? Type {  get; set; }


    }
}
