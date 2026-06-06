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
    public class LeavePolicyEligiblesController : ControllerBase
    {
        private readonly ILeavePolicyEligibleRepository _leavePolicyEligiblesRepository;

        public LeavePolicyEligiblesController(ILeavePolicyEligibleRepository leavePolicyEligiblesRepository)
        {
            _leavePolicyEligiblesRepository = leavePolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeavePolicyEligibleDTO>> GetLeavePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _leavePolicyEligiblesRepository.GetLeavePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeavePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyEligiblesRepository.SetLeavePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostLeavePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyEligiblesRepository.PostLeavePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelLeavePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyEligiblesRepository.DelLeavePolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeavePolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _leavePolicyEligiblesRepository.LookUpLeavePolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeavePolicyEligibleViewModel> GetInfoLeavePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _leavePolicyEligiblesRepository.GetInfoLeavePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeavePolicyEligibleViewModel> PrintLeavePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _leavePolicyEligiblesRepository.PrintLeavePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeavePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyEligiblesRepository.ApproveLeavePolicyEligiblesAsync(common);
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
