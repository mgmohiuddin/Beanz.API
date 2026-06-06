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
    public class EndOfServicePoliciesController : ControllerBase
    {
        private readonly IEndOfServicePolicieRepository _endOfServicePoliciesRepository;

        public EndOfServicePoliciesController(IEndOfServicePolicieRepository endOfServicePoliciesRepository)
        {
            _endOfServicePoliciesRepository = endOfServicePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServicePolicieDTO>> GetEndOfServicePolicies(BeanzCommonDTO common)
        {
            var data = await _endOfServicePoliciesRepository.GetEndOfServicePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServicePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePoliciesRepository.SetEndOfServicePoliciesAsync(common);
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
        public async Task<ActionResult> PostEndOfServicePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePoliciesRepository.PostEndOfServicePoliciesAsync(common);
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
        public async Task<ActionResult> DelEndOfServicePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePoliciesRepository.DelEndOfServicePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicies(BeanzCommonDTO lookup)
        {
            var data = await _endOfServicePoliciesRepository.LookUpEndOfServicePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServicePolicieViewModel> GetInfoEndOfServicePolicies(BeanzCommonDTO common)
        {
            var data = await _endOfServicePoliciesRepository.GetInfoEndOfServicePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServicePolicieViewModel> PrintEndOfServicePolicies(BeanzCommonDTO common)
        {
            var data = await _endOfServicePoliciesRepository.PrintEndOfServicePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServicePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePoliciesRepository.ApproveEndOfServicePoliciesAsync(common);
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
