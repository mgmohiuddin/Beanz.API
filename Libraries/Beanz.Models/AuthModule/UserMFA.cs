using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public enum MFAType { Email, SMS, Authenticator }

    public class UserMFA
    {
        public long UserMFAID { get; set; }
        public int UserID { get; set; }
        public string MFAType { get; set; } = default!;
        public string? SecretKey { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
