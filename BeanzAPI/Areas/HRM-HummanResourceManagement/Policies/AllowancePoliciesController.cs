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
    public class AllowancePoliciesController : ControllerBase
    {
        private readonly IAllowancePolicieRepository _allowancePoliciesRepository;

        public AllowancePoliciesController(IAllowancePolicieRepository allowancePoliciesRepository)
        {
            _allowancePoliciesRepository = allowancePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowancePolicieDTO>> GetAllowancePolicies(BeanzCommonDTO common)
        {
            var data = await _allowancePoliciesRepository.GetAllowancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePoliciesRepository.SetAllowancePoliciesAsync(common);
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
        public async Task<ActionResult> PostAllowancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePoliciesRepository.PostAllowancePoliciesAsync(common);
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
        public async Task<ActionResult> DelAllowancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePoliciesRepository.DelAllowancePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowancePolicies(BeanzCommonDTO lookup)
        {
            var data = await _allowancePoliciesRepository.LookUpAllowancePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowancePolicieViewModel> GetInfoAllowancePolicies(BeanzCommonDTO common)
        {
            var data = await _allowancePoliciesRepository.GetInfoAllowancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowancePolicieViewModel> PrintAllowancePolicies(BeanzCommonDTO common)
        {
            var data = await _allowancePoliciesRepository.PrintAllowancePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowancePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePoliciesRepository.ApproveAllowancePoliciesAsync(common);
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
