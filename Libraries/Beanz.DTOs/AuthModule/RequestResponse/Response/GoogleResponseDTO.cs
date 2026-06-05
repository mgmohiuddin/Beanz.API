using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth;

namespace Beanz.DTOs.AuthModule.RequestResponse.Response
{
    public class GoogleResponseDTO
    {
        
            public bool Success { get; set; }
            public GoogleJsonWebSignature.Payload? Payload { get; set; }
            public string? Message { get; set; }
            public string? Type { get; set; }
       
    }
}
