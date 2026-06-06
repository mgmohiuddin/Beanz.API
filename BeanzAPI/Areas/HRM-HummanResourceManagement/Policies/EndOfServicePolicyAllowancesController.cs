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
    public class EndOfServicePolicyAllowancesController : ControllerBase
    {
        private readonly IEndOfServicePolicyAllowanceRepository _endOfServicePolicyAllowancesRepository;

        public EndOfServicePolicyAllowancesController(IEndOfServicePolicyAllowanceRepository endOfServicePolicyAllowancesRepository)
        {
            _endOfServicePolicyAllowancesRepository = endOfServicePolicyAllowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServicePolicyAllowanceDTO>> GetEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyAllowancesRepository.GetEndOfServicePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyAllowancesRepository.SetEndOfServicePolicyAllowancesAsync(common);
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
        public async Task<ActionResult> PostEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyAllowancesRepository.PostEndOfServicePolicyAllowancesAsync(common);
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
        public async Task<ActionResult> DelEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyAllowancesRepository.DelEndOfServicePolicyAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyAllowances(BeanzCommonDTO lookup)
        {
            var data = await _endOfServicePolicyAllowancesRepository.LookUpEndOfServicePolicyAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServicePolicyAllowanceViewModel> GetInfoEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyAllowancesRepository.GetInfoEndOfServicePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServicePolicyAllowanceViewModel> PrintEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyAllowancesRepository.PrintEndOfServicePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServicePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyAllowancesRepository.ApproveEndOfServicePolicyAllowancesAsync(common);
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
