using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.AuthModule.ExternalDTOs
{
    // Apple may send the user's name on FIRST consent only — UI forwards it
    public class AppleSignInDTO : ExternalIdTokenDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
