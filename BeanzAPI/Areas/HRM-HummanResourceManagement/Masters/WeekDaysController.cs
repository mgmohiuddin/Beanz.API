using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class WeekDaysController : ControllerBase
    {
        private readonly IWeekDayBusiness _weekDaysBusiness;

        public WeekDaysController(IWeekDayBusiness weekDaysBusiness)
        {
            _weekDaysBusiness = weekDaysBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<WeekDayDTO>> GetWeekDays(BeanzCommonDTO common)
        {
            var data = await _weekDaysBusiness.GetWeekDaysAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetWeekDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _weekDaysBusiness.SetWeekDaysAsync(common);
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
        public async Task<ActionResult> PostWeekDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _weekDaysBusiness.PostWeekDaysAsync(common);
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
        public async Task<ActionResult> DelWeekDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _weekDaysBusiness.DelWeekDaysAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpWeekDays(BeanzCommonDTO lookup)
        {
            var data = await _weekDaysBusiness.LookUpWeekDaysAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<WeekDayViewModel> GetInfoWeekDays(BeanzCommonDTO common)
        {
            var data = await _weekDaysBusiness.GetInfoWeekDaysAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<WeekDayViewModel> PrintWeekDays(BeanzCommonDTO common)
        {
            var data = await _weekDaysBusiness.PrintWeekDaysAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveWeekDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _weekDaysBusiness.ApproveWeekDaysAsync(common);
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
