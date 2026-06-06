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
    public class InsurancePolicyEligiblesController : ControllerBase
    {
        private readonly IInsurancePolicyEligibleRepository _insurancePolicyEligiblesRepository;

        public InsurancePolicyEligiblesController(IInsurancePolicyEligibleRepository insurancePolicyEligiblesRepository)
        {
            _insurancePolicyEligiblesRepository = insurancePolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<InsurancePolicyEligibleDTO>> GetInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _insurancePolicyEligiblesRepository.GetInsurancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePolicyEligiblesRepository.SetInsurancePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePolicyEligiblesRepository.PostInsurancePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePolicyEligiblesRepository.DelInsurancePolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpInsurancePolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _insurancePolicyEligiblesRepository.LookUpInsurancePolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<InsurancePolicyEligibleViewModel> GetInfoInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _insurancePolicyEligiblesRepository.GetInfoInsurancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<InsurancePolicyEligibleViewModel> PrintInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _insurancePolicyEligiblesRepository.PrintInsurancePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveInsurancePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePolicyEligiblesRepository.ApproveInsurancePolicyEligiblesAsync(common);
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
