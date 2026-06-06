using Beanz.Core.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HummanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Transactions
{
    [Route("api/[area]/Transactions/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class LeaveDaysController : ControllerBase
    {
        private readonly ILeaveDayRepository _leaveDaysRepository;

        public LeaveDaysController(ILeaveDayRepository leaveDaysRepository)
        {
            _leaveDaysRepository = leaveDaysRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeaveDayDTO>> GetLeaveDays(BeanzCommonDTO common)
        {
            var data = await _leaveDaysRepository.GetLeaveDaysAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeaveDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveDaysRepository.SetLeaveDaysAsync(common);
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
        public async Task<ActionResult> PostLeaveDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveDaysRepository.PostLeaveDaysAsync(common);
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
        public async Task<ActionResult> DelLeaveDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveDaysRepository.DelLeaveDaysAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeaveDays(BeanzCommonDTO lookup)
        {
            var data = await _leaveDaysRepository.LookUpLeaveDaysAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeaveDayViewModel> GetInfoLeaveDays(BeanzCommonDTO common)
        {
            var data = await _leaveDaysRepository.GetInfoLeaveDaysAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeaveDayViewModel> PrintLeaveDays(BeanzCommonDTO common)
        {
            var data = await _leaveDaysRepository.PrintLeaveDaysAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeaveDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leaveDaysRepository.ApproveLeaveDaysAsync(common);
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
