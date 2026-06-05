using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    // GitHub — returns an authorization 'code' that we exchange server-side
    public class GitHubCodeDTO
    {
        [Required] public string Code { get; set; } = string.Empty;
        [Required] public string RedirectUri { get; set; } = string.Empty;
    }
}
