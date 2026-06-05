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
    public class LoanPoliciesController : ControllerBase
    {
        private readonly ILoanPolicieRepository _loanPoliciesRepository;

        public LoanPoliciesController(ILoanPolicieRepository loanPoliciesRepository)
        {
            _loanPoliciesRepository = loanPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LoanPolicieDTO>> GetLoanPolicies(BeanzCommonDTO common)
        {
            var data = await _loanPoliciesRepository.GetLoanPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLoanPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPoliciesRepository.SetLoanPoliciesAsync(common);
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
        public async Task<ActionResult> PostLoanPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPoliciesRepository.PostLoanPoliciesAsync(common);
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
        public async Task<ActionResult> DelLoanPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPoliciesRepository.DelLoanPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLoanPolicies(BeanzCommonDTO lookup)
        {
            var data = await _loanPoliciesRepository.LookUpLoanPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LoanPolicieViewModel> GetInfoLoanPolicies(BeanzCommonDTO common)
        {
            var data = await _loanPoliciesRepository.GetInfoLoanPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LoanPolicieViewModel> PrintLoanPolicies(BeanzCommonDTO common)
        {
            var data = await _loanPoliciesRepository.PrintLoanPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLoanPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanPoliciesRepository.ApproveLoanPoliciesAsync(common);
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
