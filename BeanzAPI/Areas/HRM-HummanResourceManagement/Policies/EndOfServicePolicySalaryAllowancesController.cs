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
    public class EndOfServicePolicySalaryAllowancesController : ControllerBase
    {
        private readonly IEndOfServicePolicySalaryAllowanceRepository _endOfServicePolicySalaryAllowancesRepository;

        public EndOfServicePolicySalaryAllowancesController(IEndOfServicePolicySalaryAllowanceRepository endOfServicePolicySalaryAllowancesRepository)
        {
            _endOfServicePolicySalaryAllowancesRepository = endOfServicePolicySalaryAllowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServicePolicySalaryAllowanceDTO>> GetEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicySalaryAllowancesRepository.GetEndOfServicePolicySalaryAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicySalaryAllowancesRepository.SetEndOfServicePolicySalaryAllowancesAsync(common);
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
        public async Task<ActionResult> PostEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicySalaryAllowancesRepository.PostEndOfServicePolicySalaryAllowancesAsync(common);
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
        public async Task<ActionResult> DelEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicySalaryAllowancesRepository.DelEndOfServicePolicySalaryAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicySalaryAllowances(BeanzCommonDTO lookup)
        {
            var data = await _endOfServicePolicySalaryAllowancesRepository.LookUpEndOfServicePolicySalaryAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServicePolicySalaryAllowanceViewModel> GetInfoEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicySalaryAllowancesRepository.GetInfoEndOfServicePolicySalaryAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServicePolicySalaryAllowanceViewModel> PrintEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            var data = await _endOfServicePolicySalaryAllowancesRepository.PrintEndOfServicePolicySalaryAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServicePolicySalaryAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServicePolicySalaryAllowancesRepository.ApproveEndOfServicePolicySalaryAllowancesAsync(common);
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
