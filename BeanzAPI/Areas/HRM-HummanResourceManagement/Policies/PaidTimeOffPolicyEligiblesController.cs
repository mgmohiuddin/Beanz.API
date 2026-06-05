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
    public class PaidTimeOffPolicyEligiblesController : ControllerBase
    {
        private readonly IPaidTimeOffPolicyEligibleRepository _paidTimeOffPolicyEligiblesRepository;

        public PaidTimeOffPolicyEligiblesController(IPaidTimeOffPolicyEligibleRepository paidTimeOffPolicyEligiblesRepository)
        {
            _paidTimeOffPolicyEligiblesRepository = paidTimeOffPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PaidTimeOffPolicyEligibleDTO>> GetPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyEligiblesRepository.GetPaidTimeOffPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyEligiblesRepository.SetPaidTimeOffPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyEligiblesRepository.PostPaidTimeOffPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyEligiblesRepository.DelPaidTimeOffPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _paidTimeOffPolicyEligiblesRepository.LookUpPaidTimeOffPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PaidTimeOffPolicyEligibleViewModel> GetInfoPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyEligiblesRepository.GetInfoPaidTimeOffPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PaidTimeOffPolicyEligibleViewModel> PrintPaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffPolicyEligiblesRepository.PrintPaidTimeOffPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePaidTimeOffPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffPolicyEligiblesRepository.ApprovePaidTimeOffPolicyEligiblesAsync(common);
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
