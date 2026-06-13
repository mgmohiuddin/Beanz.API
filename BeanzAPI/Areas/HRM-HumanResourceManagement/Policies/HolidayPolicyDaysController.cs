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
    public class HolidayPolicyDaysController : ControllerBase
    {
        private readonly IHolidayPolicyDayRepository _holidayPolicyDaysRepository;

        public HolidayPolicyDaysController(IHolidayPolicyDayRepository holidayPolicyDaysRepository)
        {
            _holidayPolicyDaysRepository = holidayPolicyDaysRepository;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayPolicyDayDTO>> GetHolidayPolicyDays(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyDaysRepository.GetHolidayPolicyDaysAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayPolicyDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyDaysRepository.SetHolidayPolicyDaysAsync(common);
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
        public async Task<ActionResult> PostHolidayPolicyDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyDaysRepository.PostHolidayPolicyDaysAsync(common);
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
        public async Task<ActionResult> DelHolidayPolicyDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyDaysRepository.DelHolidayPolicyDaysAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpHolidayPolicyDays(BeanzCommonDTO lookup)
        {
            var data = await _holidayPolicyDaysRepository.LookUpHolidayPolicyDaysAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayPolicyDayViewModel> GetInfoHolidayPolicyDays(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyDaysRepository.GetInfoHolidayPolicyDaysAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayPolicyDayViewModel> PrintHolidayPolicyDays(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyDaysRepository.PrintHolidayPolicyDaysAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayPolicyDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyDaysRepository.ApproveHolidayPolicyDaysAsync(common);
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
