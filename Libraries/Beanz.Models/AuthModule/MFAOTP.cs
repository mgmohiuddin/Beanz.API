using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public class MFAOTP
    {
        public int OTPID { get; set; }
        public int? UserID { get; set; }
        public string MFAToken { get; set; } = default!;
        public string OTPHash { get; set; } = default!;
        public string MFAType { get; set; } = default!;
        public string Purpose { get; set; } = "Login";
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedDate { get; set; }
        public int RetryCount { get; set; }
        public string? IPAddress { get; set; }
    }
}
