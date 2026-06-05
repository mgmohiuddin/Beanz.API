using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class TwitterCallbackDTO
    {
        public string Code { get; set; } = default!;
        public string State { get; set; } = default!;
        public string CodeVerifier { get; set; } = default!;  // PKCE — stored server-side keyed by state
    }

    public class TwitterTokenResponse
    {
        public string Access_token { get; set; } = default!;
        public string? Refresh_token { get; set; }
        public int Expires_in { get; set; }
    }

    public class TwitterMeResponse
    {
        public TwitterUser Data { get; set; } = new();
    }
    public class TwitterUser
    {
        public string Id { get; set; } = default!;
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Profile_image_url { get; set; }
    }
}
