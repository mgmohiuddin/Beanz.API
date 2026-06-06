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
    public class LoanPolicyEligiblesController : ControllerBase
    {
        private readonly ILoanPolicyEligibleRepository _loanPolicyEligiblesRepository;

        public LoanPolicyEligiblesController(ILoanPolicyEligibleRepository loanPolicyEligiblesRepository)
        {
            _loanPolicyEligiblesRepository = loanPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LoanPolicyEligibleDTO>> GetLoanPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _loanPolicyEligiblesRepository.GetLoanPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLoanPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyEligiblesRepository.SetLoanPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostLoanPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyEligiblesRepository.PostLoanPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelLoanPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyEligiblesRepository.DelLoanPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLoanPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _loanPolicyEligiblesRepository.LookUpLoanPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LoanPolicyEligibleViewModel> GetInfoLoanPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _loanPolicyEligiblesRepository.GetInfoLoanPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LoanPolicyEligibleViewModel> PrintLoanPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _loanPolicyEligiblesRepository.PrintLoanPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLoanPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPolicyEligiblesRepository.ApproveLoanPolicyEligiblesAsync(common);
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
