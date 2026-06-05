using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public class UserToken
    {
        public int? UserTokenID { get; set; }
        public int? UserID { get; set; }
        public string JWTID { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsRevoked { get; set; }
        public bool IsBlacklisted { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string? RevokedReason { get; set; }
        public string? DeviceInfo { get; set; }
        public string? IPAddress { get; set; }
    }
}
