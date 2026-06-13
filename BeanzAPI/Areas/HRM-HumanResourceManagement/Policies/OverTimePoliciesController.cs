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
    public class OverTimePoliciesController : ControllerBase
    {
        private readonly IOverTimePolicieRepository _overTimePoliciesRepository;

        public OverTimePoliciesController(IOverTimePolicieRepository overTimePoliciesRepository)
        {
            _overTimePoliciesRepository = overTimePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<OverTimePolicieDTO>> GetOverTimePolicies(BeanzCommonDTO common)
        {
            var data = await _overTimePoliciesRepository.GetOverTimePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOverTimePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePoliciesRepository.SetOverTimePoliciesAsync(common);
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
        public async Task<ActionResult> PostOverTimePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePoliciesRepository.PostOverTimePoliciesAsync(common);
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
        public async Task<ActionResult> DelOverTimePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePoliciesRepository.DelOverTimePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOverTimePolicies(BeanzCommonDTO lookup)
        {
            var data = await _overTimePoliciesRepository.LookUpOverTimePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OverTimePolicieViewModel> GetInfoOverTimePolicies(BeanzCommonDTO common)
        {
            var data = await _overTimePoliciesRepository.GetInfoOverTimePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OverTimePolicieViewModel> PrintOverTimePolicies(BeanzCommonDTO common)
        {
            var data = await _overTimePoliciesRepository.PrintOverTimePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOverTimePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePoliciesRepository.ApproveOverTimePoliciesAsync(common);
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
