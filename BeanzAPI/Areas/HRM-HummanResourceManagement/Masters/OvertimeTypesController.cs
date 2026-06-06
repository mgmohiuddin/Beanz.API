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
    public class OvertimeTypesController : ControllerBase
    {
        private readonly IOvertimeTypeBusiness _overtimeTypesBusiness;

        public OvertimeTypesController(IOvertimeTypeBusiness overtimeTypesBusiness)
        {
            _overtimeTypesBusiness = overtimeTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<OvertimeTypeDTO>> GetOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesBusiness.GetOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesBusiness.SetOvertimeTypesAsync(common);
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
        public async Task<ActionResult> PostOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesBusiness.PostOvertimeTypesAsync(common);
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
        public async Task<ActionResult> DelOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesBusiness.DelOvertimeTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOvertimeTypes(BeanzCommonDTO lookup)
        {
            var data = await _overtimeTypesBusiness.LookUpOvertimeTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OvertimeTypeViewModel> GetInfoOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesBusiness.GetInfoOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OvertimeTypeViewModel> PrintOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesBusiness.PrintOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesBusiness.ApproveOvertimeTypesAsync(common);
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
