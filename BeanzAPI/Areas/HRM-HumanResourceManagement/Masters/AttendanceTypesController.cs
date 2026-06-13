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
    public class AttendanceTypesController : ControllerBase
    {
        private readonly IAttendanceTypeBusiness _attendanceTypesBusiness;

        public AttendanceTypesController(IAttendanceTypeBusiness attendanceTypesBusiness)
        {
            _attendanceTypesBusiness = attendanceTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AttendanceTypeDTO>> GetAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesBusiness.GetAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesBusiness.SetAttendanceTypesAsync(common);
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
        public async Task<ActionResult> PostAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesBusiness.PostAttendanceTypesAsync(common);
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
        public async Task<ActionResult> DelAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesBusiness.DelAttendanceTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAttendanceTypes(BeanzCommonDTO lookup)
        {
            var data = await _attendanceTypesBusiness.LookUpAttendanceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AttendanceTypeViewModel> GetInfoAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesBusiness.GetInfoAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AttendanceTypeViewModel> PrintAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesBusiness.PrintAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesBusiness.ApproveAttendanceTypesAsync(common);
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
