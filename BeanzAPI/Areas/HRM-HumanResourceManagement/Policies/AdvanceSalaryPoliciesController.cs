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
    public class AdvanceSalaryPoliciesController : ControllerBase
    {
        private readonly IAdvanceSalaryPolicieRepository _advanceSalaryPoliciesRepository;

        public AdvanceSalaryPoliciesController(IAdvanceSalaryPolicieRepository advanceSalaryPoliciesRepository)
        {
            _advanceSalaryPoliciesRepository = advanceSalaryPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AdvanceSalaryPolicieDTO>> GetAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPoliciesRepository.GetAdvanceSalaryPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPoliciesRepository.SetAdvanceSalaryPoliciesAsync(common);
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
        public async Task<ActionResult> PostAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPoliciesRepository.PostAdvanceSalaryPoliciesAsync(common);
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
        public async Task<ActionResult> DelAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPoliciesRepository.DelAdvanceSalaryPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicies(BeanzCommonDTO lookup)
        {
            var data = await _advanceSalaryPoliciesRepository.LookUpAdvanceSalaryPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryPolicieViewModel> GetInfoAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPoliciesRepository.GetInfoAdvanceSalaryPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryPolicieViewModel> PrintAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPoliciesRepository.PrintAdvanceSalaryPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPoliciesRepository.ApproveAdvanceSalaryPoliciesAsync(common);
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
