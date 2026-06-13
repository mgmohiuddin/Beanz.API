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
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicieRepository _insurancePoliciesRepository;

        public InsurancePoliciesController(IInsurancePolicieRepository insurancePoliciesRepository)
        {
            _insurancePoliciesRepository = insurancePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<InsurancePolicieDTO>> GetInsurancePolicies(BeanzCommonDTO common)
        {
            var data = await _insurancePoliciesRepository.GetInsurancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetInsurancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePoliciesRepository.SetInsurancePoliciesAsync(common);
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
        public async Task<ActionResult> PostInsurancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePoliciesRepository.PostInsurancePoliciesAsync(common);
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
        public async Task<ActionResult> DelInsurancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePoliciesRepository.DelInsurancePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpInsurancePolicies(BeanzCommonDTO lookup)
        {
            var data = await _insurancePoliciesRepository.LookUpInsurancePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<InsurancePolicieViewModel> GetInfoInsurancePolicies(BeanzCommonDTO common)
        {
            var data = await _insurancePoliciesRepository.GetInfoInsurancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<InsurancePolicieViewModel> PrintInsurancePolicies(BeanzCommonDTO common)
        {
            var data = await _insurancePoliciesRepository.PrintInsurancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveInsurancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insurancePoliciesRepository.ApproveInsurancePoliciesAsync(common);
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
