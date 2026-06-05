using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public class User
    {
        public int? UserID { get; set; }
        public Guid UserGuid { get; set; }

        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

        public string? MobileNumber { get; set; }
        public string? CountryCode { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? AvatarUrl { get; set; }
        public string? AvatarName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? PreferredLanguage { get; set; }
        public string? TimeZone { get; set; }

        public bool EmailVerified { get; set; }
        public bool MobileVerified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public bool AllowMultipleLogin { get; set; } = true;
        public bool MFAEnabled { get; set; }

        public DateTime CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }

        public int? LanguageID { get; set; }
    }
}
