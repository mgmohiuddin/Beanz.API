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
    public class BonusPolicyEligiblesController : ControllerBase
    {
        private readonly IBonusPolicyEligibleRepository _bonusPolicyEligiblesRepository;

        public BonusPolicyEligiblesController(IBonusPolicyEligibleRepository bonusPolicyEligiblesRepository)
        {
            _bonusPolicyEligiblesRepository = bonusPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BonusPolicyEligibleDTO>> GetBonusPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyEligiblesRepository.GetBonusPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBonusPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyEligiblesRepository.SetBonusPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostBonusPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyEligiblesRepository.PostBonusPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelBonusPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyEligiblesRepository.DelBonusPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBonusPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _bonusPolicyEligiblesRepository.LookUpBonusPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BonusPolicyEligibleViewModel> GetInfoBonusPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyEligiblesRepository.GetInfoBonusPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BonusPolicyEligibleViewModel> PrintBonusPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyEligiblesRepository.PrintBonusPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBonusPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyEligiblesRepository.ApproveBonusPolicyEligiblesAsync(common);
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
