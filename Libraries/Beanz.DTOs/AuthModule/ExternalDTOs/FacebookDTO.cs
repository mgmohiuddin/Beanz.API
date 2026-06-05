using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class FacebookSignInDTO
    {
        public string AccessToken { get; set; } = default!;
    }

    public class FacebookProfileDTO
    {
        public string Id { get; set; } = default!;
        public string? Email { get; set; }
        public string? Name { get; set; }
        public FacebookPictureData? Picture { get; set; }
    }

    public class FacebookPictureData
    {
        public FacebookPicture Data { get; set; } = new();
    }
    public class FacebookPicture
    {
        public string? Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
