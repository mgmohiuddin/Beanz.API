using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AllowanceTypesController : ControllerBase
    {
        private readonly IAllowanceTypeBusiness _allowanceTypesBusiness;

        public AllowanceTypesController(IAllowanceTypeBusiness allowanceTypesBusiness)
        {
            _allowanceTypesBusiness = allowanceTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AllowanceTypeDTO>> GetAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesBusiness.GetAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesBusiness.SetAllowanceTypesAsync(common);
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
        public async Task<ActionResult> PostAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesBusiness.PostAllowanceTypesAsync(common);
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
        public async Task<ActionResult> DelAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesBusiness.DelAllowanceTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowanceTypes(BeanzCommonDTO lookup)
        {
            var data = await _allowanceTypesBusiness.LookUpAllowanceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowanceTypeViewModel> GetInfoAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesBusiness.GetInfoAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowanceTypeViewModel> PrintAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesBusiness.PrintAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesBusiness.ApproveAllowanceTypesAsync(common);
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
