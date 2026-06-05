using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Controllers.General
{
    [ApiController]
    [Route("api/secure")]
    public class SecureController : ControllerBase
    {
        [Authorize]
        [HttpGet("data")]
        public async Task<IActionResult> GetSecureDataAsync()
        {
            return await Task.FromResult(Ok(new { Message = "Secure Data Accessed!" }));
        }
    }

}
