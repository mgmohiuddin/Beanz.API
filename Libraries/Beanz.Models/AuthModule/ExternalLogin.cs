using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beanz.Models.AuthModule
{

    [Table("ExternalLogins", Schema = "auth")]
    public class ExternalLogin
    {
        [Key]
        public long ExternalLoginID { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required, MaxLength(50)]
        public string Provider { get; set; } = default!;

        [Required, MaxLength(255)]
        public string ProviderUserId { get; set; } = default!;

        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? DisplayName { get; set; }

        [MaxLength(1000)]
        public string? PictureUrl { get; set; }

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiresAtUtc { get; set; }
        public string? RawProfileJson { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
    }
    //public class ExternalLogin
    //{
    //    public long ExternalLoginID { get; set; }
    //    public long UserID { get; set; }
    //    public string Provider { get; set; } = string.Empty;  // Google | Microsoft | Facebook | Apple | GitHub
    //    public string ProviderUserId { get; set; } = string.Empty;  // 'sub' from provider
    //    public string? Email { get; set; }
    //    public string? DisplayName { get; set; }
    //    public string? PictureUrl { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public DateTime? LastLoginDate { get; set; }
    //}
}
