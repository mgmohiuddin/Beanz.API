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
    public class AttendancePolicyPaymentsController : ControllerBase
    {
        private readonly IAttendancePolicyPaymentRepository _attendancePolicyPaymentsRepository;

        public AttendancePolicyPaymentsController(IAttendancePolicyPaymentRepository attendancePolicyPaymentsRepository)
        {
            _attendancePolicyPaymentsRepository = attendancePolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AttendancePolicyPaymentDTO>> GetAttendancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyPaymentsRepository.GetAttendancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAttendancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyPaymentsRepository.SetAttendancePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostAttendancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyPaymentsRepository.PostAttendancePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelAttendancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyPaymentsRepository.DelAttendancePolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAttendancePolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _attendancePolicyPaymentsRepository.LookUpAttendancePolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AttendancePolicyPaymentViewModel> GetInfoAttendancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyPaymentsRepository.GetInfoAttendancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AttendancePolicyPaymentViewModel> PrintAttendancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _attendancePolicyPaymentsRepository.PrintAttendancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAttendancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _attendancePolicyPaymentsRepository.ApproveAttendancePolicyPaymentsAsync(common);
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
