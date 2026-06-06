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
    public class GosiPolicyEligiblesController : ControllerBase
    {
        private readonly IGosiPolicyEligibleRepository _gosiPolicyEligiblesRepository;

        public GosiPolicyEligiblesController(IGosiPolicyEligibleRepository gosiPolicyEligiblesRepository)
        {
            _gosiPolicyEligiblesRepository = gosiPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GosiPolicyEligibleDTO>> GetGosiPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyEligiblesRepository.GetGosiPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyEligiblesRepository.SetGosiPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostGosiPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyEligiblesRepository.PostGosiPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelGosiPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyEligiblesRepository.DelGosiPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGosiPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _gosiPolicyEligiblesRepository.LookUpGosiPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiPolicyEligibleViewModel> GetInfoGosiPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyEligiblesRepository.GetInfoGosiPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiPolicyEligibleViewModel> PrintGosiPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyEligiblesRepository.PrintGosiPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyEligiblesRepository.ApproveGosiPolicyEligiblesAsync(common);
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
