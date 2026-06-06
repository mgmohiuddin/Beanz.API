using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class HolidayPolicyPaymentsController : ControllerBase
    {
        private readonly IHolidayPolicyPaymentRepository _holidayPolicyPaymentsRepository;

        public HolidayPolicyPaymentsController(IHolidayPolicyPaymentRepository holidayPolicyPaymentsRepository)
        {
            _holidayPolicyPaymentsRepository = holidayPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayPolicyPaymentDTO>> GetHolidayPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyPaymentsRepository.GetHolidayPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyPaymentsRepository.SetHolidayPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostHolidayPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyPaymentsRepository.PostHolidayPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelHolidayPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyPaymentsRepository.DelHolidayPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpHolidayPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _holidayPolicyPaymentsRepository.LookUpHolidayPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayPolicyPaymentViewModel> GetInfoHolidayPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyPaymentsRepository.GetInfoHolidayPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayPolicyPaymentViewModel> PrintHolidayPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyPaymentsRepository.PrintHolidayPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyPaymentsRepository.ApproveHolidayPolicyPaymentsAsync(common);
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
