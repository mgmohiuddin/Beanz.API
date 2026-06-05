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
    public class GosiPolicyDetailsController : ControllerBase
    {
        private readonly IGosiPolicyDetailRepository _gosiPolicyDetailsRepository;

        public GosiPolicyDetailsController(IGosiPolicyDetailRepository gosiPolicyDetailsRepository)
        {
            _gosiPolicyDetailsRepository = gosiPolicyDetailsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GosiPolicyDetailDTO>> GetGosiPolicyDetails(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyDetailsRepository.GetGosiPolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiPolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyDetailsRepository.SetGosiPolicyDetailsAsync(common);
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
        public async Task<ActionResult> PostGosiPolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyDetailsRepository.PostGosiPolicyDetailsAsync(common);
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
        public async Task<ActionResult> DelGosiPolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyDetailsRepository.DelGosiPolicyDetailsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGosiPolicyDetails(BeanzCommonDTO lookup)
        {
            var data = await _gosiPolicyDetailsRepository.LookUpGosiPolicyDetailsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiPolicyDetailViewModel> GetInfoGosiPolicyDetails(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyDetailsRepository.GetInfoGosiPolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiPolicyDetailViewModel> PrintGosiPolicyDetails(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyDetailsRepository.PrintGosiPolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiPolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyDetailsRepository.ApproveGosiPolicyDetailsAsync(common);
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
