using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class AttendancePolicyEligiblesController : ControllerBase
    {
        private readonly IAttendancePolicyEligibleRepository _attendancePolicyEligiblesRepository;

        public AttendancePolicyEligiblesController(IAttendancePolicyEligibleRepository attendancePolicyEligiblesRepository)
        {
            _attendancePolicyEligiblesRepository = attendancePolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AttendancePolicyEligibleDTO>> GetAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyEligiblesRepository.GetAttendancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyEligiblesRepository.SetAttendancePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyEligiblesRepository.PostAttendancePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyEligiblesRepository.DelAttendancePolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAttendancePolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _attendancePolicyEligiblesRepository.LookUpAttendancePolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AttendancePolicyEligibleViewModel> GetInfoAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyEligiblesRepository.GetInfoAttendancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AttendancePolicyEligibleViewModel> PrintAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyEligiblesRepository.PrintAttendancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAttendancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyEligiblesRepository.ApproveAttendancePolicyEligiblesAsync(common);
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
