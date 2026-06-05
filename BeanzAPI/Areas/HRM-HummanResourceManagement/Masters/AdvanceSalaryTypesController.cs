using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AdvanceSalaryTypesController : ControllerBase
    {
        private readonly IAdvanceSalaryTypeRepository _advanceSalaryTypesRepository;

        public AdvanceSalaryTypesController(IAdvanceSalaryTypeRepository advanceSalaryTypesRepository)
        {
            _advanceSalaryTypesRepository = advanceSalaryTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesRepository.GetAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesRepository.SetAdvanceSalaryTypesAsync(common);
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
        public async Task<ActionResult> PostAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesRepository.PostAdvanceSalaryTypesAsync(common);
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
        public async Task<ActionResult> DelAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesRepository.DelAdvanceSalaryTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypes(BeanzCommonDTO lookup)
        {
            var data = await _advanceSalaryTypesRepository.LookUpAdvanceSalaryTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesRepository.GetInfoAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesRepository.PrintAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesRepository.ApproveAdvanceSalaryTypesAsync(common);
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
