using Beanz.Core.Areas.System.Setup;
using Beanz.DTOs.Areas.System.Setup;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.System.Setup
{
    [Route("api/[area]/Setup/[controller]/[action]")]
    [ApiController]
    [Area("System")]
    public class SystemScreensController : ControllerBase
    {
        private readonly ISystemScreenRepository _systemScreensRepository;

        public SystemScreensController(ISystemScreenRepository systemScreensRepository)
        {
            _systemScreensRepository = systemScreensRepository;
        }

        [HttpPost("Get")]
        public async Task<List<SystemScreenDTO>> GetSystemScreens(BeanzCommonDTO common)
        {
            var data = await _systemScreensRepository.GetSystemScreensAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSystemScreens(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreensRepository.SetSystemScreensAsync(common);
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
        public async Task<ActionResult> PostSystemScreens(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreensRepository.PostSystemScreensAsync(common);
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
        public async Task<ActionResult> DelSystemScreens(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreensRepository.DelSystemScreensAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpSystemScreens(BeanzCommonDTO lookup)
        {
            var data = await _systemScreensRepository.LookUpSystemScreensAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SystemScreenViewModel> GetInfoSystemScreens(BeanzCommonDTO common)
        {
            var data = await _systemScreensRepository.GetInfoSystemScreensAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SystemScreenViewModel> PrintSystemScreens(BeanzCommonDTO common)
        {
            var data = await _systemScreensRepository.PrintSystemScreensAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSystemScreens(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemScreensRepository.ApproveSystemScreensAsync(common);
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
