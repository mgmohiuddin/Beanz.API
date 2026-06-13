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
    public class OvertimePolicyPaymentsController : ControllerBase
    {
        private readonly IOvertimePolicyPaymentRepository _overtimePolicyPaymentsRepository;

        public OvertimePolicyPaymentsController(IOvertimePolicyPaymentRepository overtimePolicyPaymentsRepository)
        {
            _overtimePolicyPaymentsRepository = overtimePolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<OvertimePolicyPaymentDTO>> GetOvertimePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyPaymentsRepository.GetOvertimePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOvertimePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyPaymentsRepository.SetOvertimePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostOvertimePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyPaymentsRepository.PostOvertimePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelOvertimePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyPaymentsRepository.DelOvertimePolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOvertimePolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _overtimePolicyPaymentsRepository.LookUpOvertimePolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OvertimePolicyPaymentViewModel> GetInfoOvertimePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyPaymentsRepository.GetInfoOvertimePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OvertimePolicyPaymentViewModel> PrintOvertimePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyPaymentsRepository.PrintOvertimePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOvertimePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyPaymentsRepository.ApproveOvertimePolicyPaymentsAsync(common);
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
