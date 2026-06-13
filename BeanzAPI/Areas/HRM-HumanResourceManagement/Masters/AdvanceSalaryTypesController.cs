using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class AdvanceSalaryTypesController : ControllerBase
    {
        private readonly IAdvanceSalaryTypeBusiness _advanceSalaryTypesBusiness;

        public AdvanceSalaryTypesController(IAdvanceSalaryTypeBusiness advanceSalaryTypesBusiness)
        {
            _advanceSalaryTypesBusiness = advanceSalaryTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>> GetAdvanceSalaryTypes(BeanzRequestDTO common)
        {
            
            var data = await _advanceSalaryTypesBusiness.GetAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult<BeanzResponseObjectDTO<int?>>> SetAdvanceSalaryTypes(BeanzRequestDTO common)
        {
            try
            {
                var response = await _advanceSalaryTypesBusiness.SetAdvanceSalaryTypesAsync(common);
                return response.Success
                    ? StatusCode(response.StatusCode, response)
                    : StatusCode(response.StatusCode == 0 ? 400 : response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    BeanzResponseObjectDTO<int?>.Fail(ex.Message, "ERR-01", 500));
            }
        }
        //[HttpPost("Set")]
        //public async Task<ActionResult> SetAdvanceSalaryTypes(BeanzRequestDTO common)
        //{
        //    try
        //    {
        //        BeanzResponseDTO beanzResponseDTO = await _advanceSalaryTypesBusiness.SetAdvanceSalaryTypesAsync(common);
        //        if (beanzResponseDTO.ErrorCode != "")
        //            return BadRequest(beanzResponseDTO);
        //        else
        //            return Ok(beanzResponseDTO);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        BeanzResponseDTO beanzResponseDTO = new BeanzResponseDTO();
        //        beanzResponseDTO.ErrorMessage = ex.Message;
        //        beanzResponseDTO.ErrorCode = "ERR-01";
        //        return BadRequest(beanzResponseDTO);
        //    }
        //}

        [HttpPost("Post")]
        public async Task<ActionResult> PostAdvanceSalaryTypes(BeanzRequestDTO common)
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
        public async Task<ActionResult> DelAdvanceSalaryTypes(BeanzRequestDTO common)
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
        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypes(BeanzRequestDTO lookup)
        {
            var data = await _advanceSalaryTypesBusiness.LookUpAdvanceSalaryTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypes(BeanzRequestDTO common)
        {
            var data = await _advanceSalaryTypesBusiness.GetInfoAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypes(BeanzRequestDTO common)
        {
            var data = await _advanceSalaryTypesBusiness.PrintAdvanceSalaryTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryTypes(BeanzRequestDTO common)
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
