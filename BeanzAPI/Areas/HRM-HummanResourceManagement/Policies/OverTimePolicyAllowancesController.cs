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
    public class OverTimePolicyAllowancesController : ControllerBase
    {
        private readonly IOverTimePolicyAllowanceRepository _overTimePolicyAllowancesRepository;

        public OverTimePolicyAllowancesController(IOverTimePolicyAllowanceRepository overTimePolicyAllowancesRepository)
        {
            _overTimePolicyAllowancesRepository = overTimePolicyAllowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<OverTimePolicyAllowanceDTO>> GetOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _overTimePolicyAllowancesRepository.GetOverTimePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePolicyAllowancesRepository.SetOverTimePolicyAllowancesAsync(common);
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
        public async Task<ActionResult> PostOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePolicyAllowancesRepository.PostOverTimePolicyAllowancesAsync(common);
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
        public async Task<ActionResult> DelOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePolicyAllowancesRepository.DelOverTimePolicyAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOverTimePolicyAllowances(BeanzCommonDTO lookup)
        {
            var data = await _overTimePolicyAllowancesRepository.LookUpOverTimePolicyAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OverTimePolicyAllowanceViewModel> GetInfoOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _overTimePolicyAllowancesRepository.GetInfoOverTimePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OverTimePolicyAllowanceViewModel> PrintOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            var data = await _overTimePolicyAllowancesRepository.PrintOverTimePolicyAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOverTimePolicyAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overTimePolicyAllowancesRepository.ApproveOverTimePolicyAllowancesAsync(common);
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
