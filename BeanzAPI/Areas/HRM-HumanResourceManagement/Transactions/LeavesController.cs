using Beanz.Core.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Transactions
{
    [Route("api/[area]/Transactions/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveRepository _leavesRepository;

        public LeavesController(ILeaveRepository leavesRepository)
        {
            _leavesRepository = leavesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeaveDTO>> GetLeaves(BeanzCommonDTO common)
        {
            var data = await _leavesRepository.GetLeavesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeaves(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavesRepository.SetLeavesAsync(common);
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
        public async Task<ActionResult> PostLeaves(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavesRepository.PostLeavesAsync(common);
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
        public async Task<ActionResult> DelLeaves(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavesRepository.DelLeavesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeaves(BeanzCommonDTO lookup)
        {
            var data = await _leavesRepository.LookUpLeavesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeaveViewModel> GetInfoLeaves(BeanzCommonDTO common)
        {
            var data = await _leavesRepository.GetInfoLeavesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeaveViewModel> PrintLeaves(BeanzCommonDTO common)
        {
            var data = await _leavesRepository.PrintLeavesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeaves(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavesRepository.ApproveLeavesAsync(common);
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
