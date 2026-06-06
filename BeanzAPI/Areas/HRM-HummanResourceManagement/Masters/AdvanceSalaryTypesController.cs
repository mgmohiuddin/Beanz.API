using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AdvanceSalaryTypesController : ControllerBase
    {
        private readonly IAdvanceSalaryTypeBusiness _advanceSalaryTypesBusiness;

        public AdvanceSalaryTypesController(IAdvanceSalaryTypeBusiness advanceSalaryTypesBusiness)
        {
            _advanceSalaryTypesBusiness = advanceSalaryTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesBusiness.GetAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesBusiness.SetAdvanceSalaryTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesBusiness.PostAdvanceSalaryTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesBusiness.DelAdvanceSalaryTypesAsync(common);
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
            var data = await _advanceSalaryTypesBusiness.LookUpAdvanceSalaryTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesBusiness.GetInfoAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryTypesBusiness.PrintAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesBusiness.ApproveAdvanceSalaryTypesAsync(common);
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
