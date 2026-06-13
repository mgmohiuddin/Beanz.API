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
    public class AdvanceSalaryPolicyEligiblesController : ControllerBase
    {
        private readonly IAdvanceSalaryPolicyEligibleRepository _advanceSalaryPolicyEligiblesRepository;

        public AdvanceSalaryPolicyEligiblesController(IAdvanceSalaryPolicyEligibleRepository advanceSalaryPolicyEligiblesRepository)
        {
            _advanceSalaryPolicyEligiblesRepository = advanceSalaryPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AdvanceSalaryPolicyEligibleDTO>> GetAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyEligiblesRepository.GetAdvanceSalaryPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyEligiblesRepository.SetAdvanceSalaryPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyEligiblesRepository.PostAdvanceSalaryPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyEligiblesRepository.DelAdvanceSalaryPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _advanceSalaryPolicyEligiblesRepository.LookUpAdvanceSalaryPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryPolicyEligibleViewModel> GetInfoAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyEligiblesRepository.GetInfoAdvanceSalaryPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryPolicyEligibleViewModel> PrintAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyEligiblesRepository.PrintAdvanceSalaryPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyEligiblesRepository.ApproveAdvanceSalaryPolicyEligiblesAsync(common);
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
