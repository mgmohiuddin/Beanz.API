using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class PaidTimeOffPolicyPaymentsController : ControllerBase
    {
        private readonly IPaidTimeOffPolicyPaymentRepository _paidTimeOffPolicyPaymentsRepository;

        public PaidTimeOffPolicyPaymentsController(IPaidTimeOffPolicyPaymentRepository paidTimeOffPolicyPaymentsRepository)
        {
            _paidTimeOffPolicyPaymentsRepository = paidTimeOffPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PaidTimeOffPolicyPaymentDTO>> GetPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyPaymentsRepository.GetPaidTimeOffPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyPaymentsRepository.SetPaidTimeOffPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyPaymentsRepository.PostPaidTimeOffPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyPaymentsRepository.DelPaidTimeOffPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _paidTimeOffPolicyPaymentsRepository.LookUpPaidTimeOffPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PaidTimeOffPolicyPaymentViewModel> GetInfoPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyPaymentsRepository.GetInfoPaidTimeOffPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PaidTimeOffPolicyPaymentViewModel> PrintPaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyPaymentsRepository.PrintPaidTimeOffPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePaidTimeOffPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyPaymentsRepository.ApprovePaidTimeOffPolicyPaymentsAsync(common);
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
