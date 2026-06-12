using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public class PasswordResetToken
    {
        public int? TokenID { get; set; }
        [Required]
        public int? UserID { get; set; }
        public string UserName { get; set; } = default!;
        [Required]
        public string Token { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedDate { get; set; }
        public string? IPAddress { get; set; }
        public string? VarificationLink { get; set; }

        public int? LanguageID { get; set; }
    }
}
