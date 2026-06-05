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
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveTypeRepository _leaveTypesRepository;

        public LeaveTypesController(ILeaveTypeRepository leaveTypesRepository)
        {
            _leaveTypesRepository = leaveTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeaveTypeDTO>> GetLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesRepository.GetLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesRepository.SetLeaveTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesRepository.PostLeaveTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesRepository.DelLeaveTypesAsync(common);
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
            var data = await _leaveTypesRepository.LookUpLeaveTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeaveTypeViewModel> GetInfoLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesRepository.GetInfoLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeaveTypeViewModel> PrintLeaveTypes(BeanzCommonDTO common)
        {
            var data = await _leaveTypesRepository.PrintLeaveTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeaveTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveTypesRepository.ApproveLeaveTypesAsync(common);
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
