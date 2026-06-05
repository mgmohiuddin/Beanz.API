using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse
{
    public class GeneralResponseDTO
    {
        public bool Success { get; set; }
        public int? ID { get; set; }
        public string Message { get; set; }
    }
}
