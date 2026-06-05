using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    public class GitHubCallbackDTO
    {
        public string Code { get; set; } = default!;
        public string? State { get; set; }
    }

    public class GitHubTokenResponse
    {
        public string Access_token { get; set; } = default!;
        public string? Token_type { get; set; }
        public string? Scope { get; set; }
    }

    public class GitHubProfileDTO
    {
        public long Id { get; set; }
        public string Login { get; set; } = default!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Avatar_url { get; set; }
    }

    public class GitHubEmail
    {
        public string Email { get; set; } = default!;
        public bool Primary { get; set; }
        public bool Verified { get; set; }
    }
}
