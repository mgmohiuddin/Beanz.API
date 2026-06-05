using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AttendanceTypesController : ControllerBase
    {
        private readonly IAttendanceTypeRepository _attendanceTypesRepository;

        public AttendanceTypesController(IAttendanceTypeRepository attendanceTypesRepository)
        {
            _attendanceTypesRepository = attendanceTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AttendanceTypeDTO>> GetAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesRepository.GetAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesRepository.SetAttendanceTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesRepository.PostAttendanceTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesRepository.DelAttendanceTypesAsync(common);
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
            var data = await _attendanceTypesRepository.LookUpAttendanceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AttendanceTypeViewModel> GetInfoAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesRepository.GetInfoAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AttendanceTypeViewModel> PrintAttendanceTypes(BeanzCommonDTO common)
        {
            var data = await _attendanceTypesRepository.PrintAttendanceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAttendanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendanceTypesRepository.ApproveAttendanceTypesAsync(common);
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
