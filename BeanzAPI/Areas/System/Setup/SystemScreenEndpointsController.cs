using Beanz.Core.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.BeanzSystem.Setup
{
    [Route("api/[area]/Setup/[controller]/[action]")]
    [ApiController]
    [Area("BeanzSystem")]
    public class SystemScreenEndpointsController : ControllerBase
    {
        private readonly ISystemScreenEndpointRepository _systemScreenEndpointsRepository;

        public SystemScreenEndpointsController(ISystemScreenEndpointRepository systemScreenEndpointsRepository)
        {
            _systemScreenEndpointsRepository = systemScreenEndpointsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<SystemScreenEndpointDTO>> GetSystemScreenEndpoints(BeanzCommonDTO common)
        {
            var data = await _systemScreenEndpointsRepository.GetSystemScreenEndpointsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSystemScreenEndpoints(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreenEndpointsRepository.SetSystemScreenEndpointsAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Post")]
        public async Task<ActionResult> PostSystemScreenEndpoints(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreenEndpointsRepository.PostSystemScreenEndpointsAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Del")]
        public async Task<ActionResult> DelSystemScreenEndpoints(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreenEndpointsRepository.DelSystemScreenEndpointsAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("LookUp")]
        public async Task<List<BeanzlookupDTO>> LookUpSystemScreenEndpoints(BeanzCommonDTO lookup)
        {
            var data = await _systemScreenEndpointsRepository.LookUpSystemScreenEndpointsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SystemScreenEndpointViewModel> GetInfoSystemScreenEndpoints(BeanzCommonDTO common)
        {
            var data = await _systemScreenEndpointsRepository.GetInfoSystemScreenEndpointsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SystemScreenEndpointViewModel> PrintSystemScreenEndpoints(BeanzCommonDTO common)
        {
            var data = await _systemScreenEndpointsRepository.PrintSystemScreenEndpointsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSystemScreenEndpoints(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreenEndpointsRepository.ApproveSystemScreenEndpointsAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
