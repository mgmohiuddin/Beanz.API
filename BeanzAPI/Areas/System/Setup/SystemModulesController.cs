using Beanz.Core.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.BeanzSystem.Setup
{
    [Route("api/[area]/Setup/[controller]/[action]")]
    [ApiController]
    [Area("BeanzSystem")]
    public class SystemModulesController : ControllerBase
    {
        private readonly ISystemModuleRepository _systemModulesRepository;

        public SystemModulesController(ISystemModuleRepository systemModulesRepository)
        {
            _systemModulesRepository = systemModulesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<SystemModuleDTO>> GetSystemModules(BeanzCommonDTO common)
        {
            var data = await _systemModulesRepository.GetSystemModulesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSystemModules(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemModulesRepository.SetSystemModulesAsync(common);
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
        public async Task<ActionResult> PostSystemModules(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemModulesRepository.PostSystemModulesAsync(common);
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
        public async Task<ActionResult> DelSystemModules(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemModulesRepository.DelSystemModulesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpSystemModules(BeanzCommonDTO lookup)
        {
            var data = await _systemModulesRepository.LookUpSystemModulesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SystemModuleViewModel> GetInfoSystemModules(BeanzCommonDTO common)
        {
            var data = await _systemModulesRepository.GetInfoSystemModulesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SystemModuleViewModel> PrintSystemModules(BeanzCommonDTO common)
        {
            var data = await _systemModulesRepository.PrintSystemModulesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSystemModules(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _systemModulesRepository.ApproveSystemModulesAsync(common);
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
