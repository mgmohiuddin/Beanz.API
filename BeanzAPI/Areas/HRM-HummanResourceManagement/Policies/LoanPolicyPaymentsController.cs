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
    public class LoanPolicyPaymentsController : ControllerBase
    {
        private readonly ILoanPolicyPaymentRepository _loanPolicyPaymentsRepository;

        public LoanPolicyPaymentsController(ILoanPolicyPaymentRepository loanPolicyPaymentsRepository)
        {
            _loanPolicyPaymentsRepository = loanPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LoanPolicyPaymentDTO>> GetLoanPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _loanPolicyPaymentsRepository.GetLoanPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLoanPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyPaymentsRepository.SetLoanPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostLoanPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyPaymentsRepository.PostLoanPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelLoanPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyPaymentsRepository.DelLoanPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLoanPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _loanPolicyPaymentsRepository.LookUpLoanPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LoanPolicyPaymentViewModel> GetInfoLoanPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _loanPolicyPaymentsRepository.GetInfoLoanPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LoanPolicyPaymentViewModel> PrintLoanPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _loanPolicyPaymentsRepository.PrintLoanPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLoanPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyPaymentsRepository.ApproveLoanPolicyPaymentsAsync(common);
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
