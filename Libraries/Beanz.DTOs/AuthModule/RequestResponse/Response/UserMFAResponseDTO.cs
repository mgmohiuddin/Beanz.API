using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Response
{
    public class UserMFAResponseDTO
    {


        public bool Success { get; set; }
        public int? UserMFAID { get; set; }
        public string Message { get; set; }


    }
}
