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
    public class PaidTimeOffPoliciesController : ControllerBase
    {
        private readonly IPaidTimeOffPolicieRepository _paidTimeOffPoliciesRepository;

        public PaidTimeOffPoliciesController(IPaidTimeOffPolicieRepository paidTimeOffPoliciesRepository)
        {
            _paidTimeOffPoliciesRepository = paidTimeOffPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PaidTimeOffPolicieDTO>> GetPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPoliciesRepository.GetPaidTimeOffPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPoliciesRepository.SetPaidTimeOffPoliciesAsync(common);
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
        public async Task<ActionResult> PostPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPoliciesRepository.PostPaidTimeOffPoliciesAsync(common);
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
        public async Task<ActionResult> DelPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPoliciesRepository.DelPaidTimeOffPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicies(BeanzCommonDTO lookup)
        {
            var data = await _paidTimeOffPoliciesRepository.LookUpPaidTimeOffPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PaidTimeOffPolicieViewModel> GetInfoPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPoliciesRepository.GetInfoPaidTimeOffPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PaidTimeOffPolicieViewModel> PrintPaidTimeOffPolicies(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPoliciesRepository.PrintPaidTimeOffPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePaidTimeOffPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPoliciesRepository.ApprovePaidTimeOffPoliciesAsync(common);
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
