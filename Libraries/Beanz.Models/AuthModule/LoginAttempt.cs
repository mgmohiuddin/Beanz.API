using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.AuthModule
{
    public class LoginAttempt
    {
        public long AttemptID { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public bool IsSuccess { get; set; }
        public string? FailureReason { get; set; }
        public DateTime AttemptDate { get; set; }

        public int? maxFailedAttempts { get; set; }
        public int? lockoutMinutes { get; set; }
    }
}
