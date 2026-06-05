using Beanz.Core.BeanzRoutes;
using Beanz.DTOs.BeanzCommon;

//using Beanz.Core.HospitalInformationSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;
using Pipelines.Sockets.Unofficial.Arenas;

namespace Beanz.API.Controllers.BeanzRoutes
{
   
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class BeanzPermissionController : ControllerBase
    {
        private readonly IBeanzPermissionRepository _BeanzPermissionRepository;
        public BeanzPermissionController(IBeanzPermissionRepository BeanzPermissionRepository)
        {
            _BeanzPermissionRepository = BeanzPermissionRepository;
        }

        [HttpPost]
        public async Task<List<BeanzPermissionDTO>> GetBeanzPermission(BeanzRequestDTO common)
        {
            var data = await _BeanzPermissionRepository.GetBeanzPermissionsAsync(common);
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> SetBeanzPermissions(BeanzPermissionDTO common)
        {
            try
            {
                string result = await _BeanzPermissionRepository.SetBeanzPermissionsAsync(common);
                if (result != "")
                    return BadRequest(result);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> DelBeanzPermissions(BeanzPermissionDTO common)
        {
            try
            {
                string result = await _BeanzPermissionRepository.DelBeanzPermissionsAsync(common);
                if (result != "")
                    return BadRequest(result);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<List<BeanzlookupDTO>> LookUpBeanzPermissions(BeanzPermissionDTO lookup)
        {
            var data = await _BeanzPermissionRepository.LookUpBeanzPermissionsAsync(lookup);
            return data;
        }

        //[HttpPost]
        //public async Task<BeanzPermissionViewModel> GetInfoBeanzPermissions(BeanzCommonDTO common)
        //{
        //    var data = await _BeanzPermissionRepository.GetInfoBeanzPermissionsAsync(common);
        //    return data;
        //}
    }
}