using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.UserInfoDTOs
{
    public class UserInfoDTO
    {
        public int? UserID { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string? ProfilePictureUrl { get; set; }
    }
}
