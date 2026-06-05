using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Response
{
    public class MFAOTPResponseDTO
    {


        public bool Success { get; set; }
        public int? MfaOtpID { get; set; }
        public string Message { get; set; }


    }
}
