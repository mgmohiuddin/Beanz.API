using Beanz.DTOs.AuthModule.UserInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.RequestResponse.Response
{
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime ExpiryDate { get; set; }
        public UserInfoDTO User { get; set; } = default!;
    }
}
