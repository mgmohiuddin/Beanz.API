using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Response
{
    public class AuthLoginAttemptResponseDTO
    {
        public bool Success { get; set; }
        public int? LoginAttemptID { get; set; }
        public string Message { get; set; } 
        //new SqlParameter("@Success", SqlDbType.Bit, 50) { Direction = ParameterDirection.Output },
        //new SqlParameter("@Message", SqlDbType.NVarChar) { Direction = ParameterDirection.Output },
    }
}
