using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beanz.DTOs.Common;

namespace Beanz.DTOs.Auth
{
    public class AuthForgetPasswordDTO 
    {
        public string Email { get; set; } = string.Empty;
        public long? CompanyID { get; set; }
        public long? UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
