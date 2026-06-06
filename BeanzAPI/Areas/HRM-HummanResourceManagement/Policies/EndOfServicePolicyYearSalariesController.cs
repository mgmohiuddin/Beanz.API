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
    public class EndOfServicePolicyYearSalariesController : ControllerBase
    {
        private readonly IEndOfServicePolicyYearSalarieRepository _endOfServicePolicyYearSalariesRepository;

        public EndOfServicePolicyYearSalariesController(IEndOfServicePolicyYearSalarieRepository endOfServicePolicyYearSalariesRepository)
        {
            _endOfServicePolicyYearSalariesRepository = endOfServicePolicyYearSalariesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServicePolicyYearSalarieDTO>> GetEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyYearSalariesRepository.GetEndOfServicePolicyYearSalariesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyYearSalariesRepository.SetEndOfServicePolicyYearSalariesAsync(common);
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
        public async Task<ActionResult> PostEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyYearSalariesRepository.PostEndOfServicePolicyYearSalariesAsync(common);
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
        public async Task<ActionResult> DelEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyYearSalariesRepository.DelEndOfServicePolicyYearSalariesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyYearSalaries(BeanzCommonDTO lookup)
        {
            var data = await _endOfServicePolicyYearSalariesRepository.LookUpEndOfServicePolicyYearSalariesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServicePolicyYearSalarieViewModel> GetInfoEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyYearSalariesRepository.GetInfoEndOfServicePolicyYearSalariesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServicePolicyYearSalarieViewModel> PrintEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicyYearSalariesRepository.PrintEndOfServicePolicyYearSalariesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServicePolicyYearSalaries(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicyYearSalariesRepository.ApproveEndOfServicePolicyYearSalariesAsync(common);
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
