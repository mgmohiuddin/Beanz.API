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
    public class LeavePoliciesController : ControllerBase
    {
        private readonly ILeavePolicieRepository _leavePoliciesRepository;

        public LeavePoliciesController(ILeavePolicieRepository leavePoliciesRepository)
        {
            _leavePoliciesRepository = leavePoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeavePolicieDTO>> GetLeavePolicies(BeanzCommonDTO common)
        {
            var data = await _leavePoliciesRepository.GetLeavePoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeavePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePoliciesRepository.SetLeavePoliciesAsync(common);
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
        public async Task<ActionResult> PostLeavePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePoliciesRepository.PostLeavePoliciesAsync(common);
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
        public async Task<ActionResult> DelLeavePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePoliciesRepository.DelLeavePoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeavePolicies(BeanzCommonDTO lookup)
        {
            var data = await _leavePoliciesRepository.LookUpLeavePoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeavePolicieViewModel> GetInfoLeavePolicies(BeanzCommonDTO common)
        {
            var data = await _leavePoliciesRepository.GetInfoLeavePoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeavePolicieViewModel> PrintLeavePolicies(BeanzCommonDTO common)
        {
            var data = await _leavePoliciesRepository.PrintLeavePoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeavePolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePoliciesRepository.ApproveLeavePoliciesAsync(common);
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
