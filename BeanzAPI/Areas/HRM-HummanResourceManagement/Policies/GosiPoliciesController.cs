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
    public class GosiPoliciesController : ControllerBase
    {
        private readonly IGosiPolicieRepository _gosiPoliciesRepository;

        public GosiPoliciesController(IGosiPolicieRepository gosiPoliciesRepository)
        {
            _gosiPoliciesRepository = gosiPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GosiPolicieDTO>> GetGosiPolicies(BeanzCommonDTO common)
        {
            var data = await _gosiPoliciesRepository.GetGosiPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPoliciesRepository.SetGosiPoliciesAsync(common);
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
        public async Task<ActionResult> PostGosiPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPoliciesRepository.PostGosiPoliciesAsync(common);
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
        public async Task<ActionResult> DelGosiPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPoliciesRepository.DelGosiPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGosiPolicies(BeanzCommonDTO lookup)
        {
            var data = await _gosiPoliciesRepository.LookUpGosiPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiPolicieViewModel> GetInfoGosiPolicies(BeanzCommonDTO common)
        {
            var data = await _gosiPoliciesRepository.GetInfoGosiPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiPolicieViewModel> PrintGosiPolicies(BeanzCommonDTO common)
        {
            var data = await _gosiPoliciesRepository.PrintGosiPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPoliciesRepository.ApproveGosiPoliciesAsync(common);
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
