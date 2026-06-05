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
    public class BonusPoliciesController : ControllerBase
    {
        private readonly IBonusPolicieRepository _bonusPoliciesRepository;

        public BonusPoliciesController(IBonusPolicieRepository bonusPoliciesRepository)
        {
            _bonusPoliciesRepository = bonusPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BonusPolicieDTO>> GetBonusPolicies(BeanzCommonDTO common)
        {
            var data = await _bonusPoliciesRepository.GetBonusPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBonusPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPoliciesRepository.SetBonusPoliciesAsync(common);
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
        public async Task<ActionResult> PostBonusPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPoliciesRepository.PostBonusPoliciesAsync(common);
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
        public async Task<ActionResult> DelBonusPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPoliciesRepository.DelBonusPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBonusPolicies(BeanzCommonDTO lookup)
        {
            var data = await _bonusPoliciesRepository.LookUpBonusPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BonusPolicieViewModel> GetInfoBonusPolicies(BeanzCommonDTO common)
        {
            var data = await _bonusPoliciesRepository.GetInfoBonusPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BonusPolicieViewModel> PrintBonusPolicies(BeanzCommonDTO common)
        {
            var data = await _bonusPoliciesRepository.PrintBonusPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBonusPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPoliciesRepository.ApproveBonusPoliciesAsync(common);
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
