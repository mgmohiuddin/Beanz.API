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
    public class BusinessTripPoliciesController : ControllerBase
    {
        private readonly IBusinessTripPolicieRepository _businessTripPoliciesRepository;

        public BusinessTripPoliciesController(IBusinessTripPolicieRepository businessTripPoliciesRepository)
        {
            _businessTripPoliciesRepository = businessTripPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripPolicieDTO>> GetBusinessTripPolicies(BeanzCommonDTO common)
        {
            var data = await _businessTripPoliciesRepository.GetBusinessTripPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPoliciesRepository.SetBusinessTripPoliciesAsync(common);
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
        public async Task<ActionResult> PostBusinessTripPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPoliciesRepository.PostBusinessTripPoliciesAsync(common);
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
        public async Task<ActionResult> DelBusinessTripPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPoliciesRepository.DelBusinessTripPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicies(BeanzCommonDTO lookup)
        {
            var data = await _businessTripPoliciesRepository.LookUpBusinessTripPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripPolicieViewModel> GetInfoBusinessTripPolicies(BeanzCommonDTO common)
        {
            var data = await _businessTripPoliciesRepository.GetInfoBusinessTripPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripPolicieViewModel> PrintBusinessTripPolicies(BeanzCommonDTO common)
        {
            var data = await _businessTripPoliciesRepository.PrintBusinessTripPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPoliciesRepository.ApproveBusinessTripPoliciesAsync(common);
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
