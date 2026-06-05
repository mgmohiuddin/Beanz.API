using Beanz.Core.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Transactions
{
    [Route("api/[area]/Transactions/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class LeaveOpeningBalancesController : ControllerBase
    {
        private readonly ILeaveOpeningBalanceRepository _leaveOpeningBalancesRepository;

        public LeaveOpeningBalancesController(ILeaveOpeningBalanceRepository leaveOpeningBalancesRepository)
        {
            _leaveOpeningBalancesRepository = leaveOpeningBalancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeaveOpeningBalanceDTO>> GetLeaveOpeningBalances(BeanzCommonDTO common)
        {
            var data = await _leaveOpeningBalancesRepository.GetLeaveOpeningBalancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeaveOpeningBalances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveOpeningBalancesRepository.SetLeaveOpeningBalancesAsync(common);
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
        public async Task<ActionResult> PostLeaveOpeningBalances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveOpeningBalancesRepository.PostLeaveOpeningBalancesAsync(common);
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
        public async Task<ActionResult> DelLeaveOpeningBalances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveOpeningBalancesRepository.DelLeaveOpeningBalancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeaveOpeningBalances(BeanzCommonDTO lookup)
        {
            var data = await _leaveOpeningBalancesRepository.LookUpLeaveOpeningBalancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeaveOpeningBalanceViewModel> GetInfoLeaveOpeningBalances(BeanzCommonDTO common)
        {
            var data = await _leaveOpeningBalancesRepository.GetInfoLeaveOpeningBalancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeaveOpeningBalanceViewModel> PrintLeaveOpeningBalances(BeanzCommonDTO common)
        {
            var data = await _leaveOpeningBalancesRepository.PrintLeaveOpeningBalancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeaveOpeningBalances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveOpeningBalancesRepository.ApproveLeaveOpeningBalancesAsync(common);
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
