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
    public class AttendancePoliciesController : ControllerBase
    {
        private readonly IAttendancePolicieRepository _attendancePoliciesRepository;

        public AttendancePoliciesController(IAttendancePolicieRepository attendancePoliciesRepository)
        {
            _attendancePoliciesRepository = attendancePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AttendancePolicieDTO>> GetAttendancePolicies(BeanzCommonDTO common)
        {
            var data = await _attendancePoliciesRepository.GetAttendancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAttendancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePoliciesRepository.SetAttendancePoliciesAsync(common);
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
        public async Task<ActionResult> PostAttendancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePoliciesRepository.PostAttendancePoliciesAsync(common);
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
        public async Task<ActionResult> DelAttendancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePoliciesRepository.DelAttendancePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAttendancePolicies(BeanzCommonDTO lookup)
        {
            var data = await _attendancePoliciesRepository.LookUpAttendancePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AttendancePolicieViewModel> GetInfoAttendancePolicies(BeanzCommonDTO common)
        {
            var data = await _attendancePoliciesRepository.GetInfoAttendancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AttendancePolicieViewModel> PrintAttendancePolicies(BeanzCommonDTO common)
        {
            var data = await _attendancePoliciesRepository.PrintAttendancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAttendancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePoliciesRepository.ApproveAttendancePoliciesAsync(common);
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
