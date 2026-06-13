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
    public class EndOfServicePolicyCalculationsController : ControllerBase
    {
        private readonly IEndOfServicePolicyCalculationRepository _endOfServicePolicyCalculationsRepository;

        public EndOfServicePolicyCalculationsController(IEndOfServicePolicyCalculationRepository endOfServicePolicyCalculationsRepository)
        {
            _endOfServicePolicyCalculationsRepository = endOfServicePolicyCalculationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServicePolicyCalculationDTO>> GetEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyCalculationsRepository.GetEndOfServicePolicyCalculationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyCalculationsRepository.SetEndOfServicePolicyCalculationsAsync(common);
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
        public async Task<ActionResult> PostEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyCalculationsRepository.PostEndOfServicePolicyCalculationsAsync(common);
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
        public async Task<ActionResult> DelEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyCalculationsRepository.DelEndOfServicePolicyCalculationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyCalculations(BeanzCommonDTO lookup)
        {
            var data = await _endOfServicePolicyCalculationsRepository.LookUpEndOfServicePolicyCalculationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServicePolicyCalculationViewModel> GetInfoEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyCalculationsRepository.GetInfoEndOfServicePolicyCalculationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServicePolicyCalculationViewModel> PrintEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyCalculationsRepository.PrintEndOfServicePolicyCalculationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServicePolicyCalculations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyCalculationsRepository.ApproveEndOfServicePolicyCalculationsAsync(common);
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
