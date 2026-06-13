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
    public class BusinessTripPolicyEligiblesController : ControllerBase
    {
        private readonly IBusinessTripPolicyEligibleRepository _businessTripPolicyEligiblesRepository;

        public BusinessTripPolicyEligiblesController(IBusinessTripPolicyEligibleRepository businessTripPolicyEligiblesRepository)
        {
            _businessTripPolicyEligiblesRepository = businessTripPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripPolicyEligibleDTO>> GetBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyEligiblesRepository.GetBusinessTripPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyEligiblesRepository.SetBusinessTripPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyEligiblesRepository.PostBusinessTripPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyEligiblesRepository.DelBusinessTripPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _businessTripPolicyEligiblesRepository.LookUpBusinessTripPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripPolicyEligibleViewModel> GetInfoBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyEligiblesRepository.GetInfoBusinessTripPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripPolicyEligibleViewModel> PrintBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyEligiblesRepository.PrintBusinessTripPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyEligiblesRepository.ApproveBusinessTripPolicyEligiblesAsync(common);
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
