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
    public class AllowancePolicyDetailsController : ControllerBase
    {
        private readonly IAllowancePolicyDetailRepository _allowancePolicyDetailsRepository;

        public AllowancePolicyDetailsController(IAllowancePolicyDetailRepository allowancePolicyDetailsRepository)
        {
            _allowancePolicyDetailsRepository = allowancePolicyDetailsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowancePolicyDetailDTO>> GetAllowancePolicyDetails(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyDetailsRepository.GetAllowancePolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowancePolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyDetailsRepository.SetAllowancePolicyDetailsAsync(common);
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
        public async Task<ActionResult> PostAllowancePolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyDetailsRepository.PostAllowancePolicyDetailsAsync(common);
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
        public async Task<ActionResult> DelAllowancePolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyDetailsRepository.DelAllowancePolicyDetailsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowancePolicyDetails(BeanzCommonDTO lookup)
        {
            var data = await _allowancePolicyDetailsRepository.LookUpAllowancePolicyDetailsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowancePolicyDetailViewModel> GetInfoAllowancePolicyDetails(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyDetailsRepository.GetInfoAllowancePolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowancePolicyDetailViewModel> PrintAllowancePolicyDetails(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyDetailsRepository.PrintAllowancePolicyDetailsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowancePolicyDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyDetailsRepository.ApproveAllowancePolicyDetailsAsync(common);
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
