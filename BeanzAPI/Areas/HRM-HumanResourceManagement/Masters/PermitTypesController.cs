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
    public class PermitTypesController : ControllerBase
    {
        private readonly IPermitTypeBusiness _permitTypesBusiness;

        public PermitTypesController(IPermitTypeBusiness permitTypesBusiness)
        {
            _permitTypesBusiness = permitTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<PermitTypeDTO>> GetPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesBusiness.GetPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesBusiness.SetPermitTypesAsync(common);
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
        public async Task<ActionResult> PostPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesBusiness.PostPermitTypesAsync(common);
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
        public async Task<ActionResult> DelPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesBusiness.DelPermitTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPermitTypes(BeanzCommonDTO lookup)
        {
            var data = await _permitTypesBusiness.LookUpPermitTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PermitTypeViewModel> GetInfoPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesBusiness.GetInfoPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PermitTypeViewModel> PrintPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesBusiness.PrintPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesBusiness.ApprovePermitTypesAsync(common);
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
