using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.BeanzRoutes
{
    public class BeanzResponseDTO
    {
        public int? ResponseID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
