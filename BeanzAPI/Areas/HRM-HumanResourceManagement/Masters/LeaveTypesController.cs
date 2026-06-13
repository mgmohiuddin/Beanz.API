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
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveTypeBusiness _leaveTypesBusiness;

        public LeaveTypesController(ILeaveTypeBusiness leaveTypesBusiness)
        {
            _leaveTypesBusiness = leaveTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<LeaveTypeDTO>> GetLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesBusiness.GetLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesBusiness.SetLeaveTypesAsync(common);
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
        public async Task<ActionResult> PostLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesBusiness.PostLeaveTypesAsync(common);
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
        public async Task<ActionResult> DelLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesBusiness.DelLeaveTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeaveTypes(BeanzCommonDTO lookup)
        {
            var data = await _leaveTypesBusiness.LookUpLeaveTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeaveTypeViewModel> GetInfoLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesBusiness.GetInfoLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeaveTypeViewModel> PrintLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesBusiness.PrintLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesBusiness.ApproveLeaveTypesAsync(common);
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
