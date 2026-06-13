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
    public class HolidayPolicyEligiblesController : ControllerBase
    {
        private readonly IHolidayPolicyEligibleRepository _holidayPolicyEligiblesRepository;

        public HolidayPolicyEligiblesController(IHolidayPolicyEligibleRepository holidayPolicyEligiblesRepository)
        {
            _holidayPolicyEligiblesRepository = holidayPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayPolicyEligibleDTO>> GetHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyEligiblesRepository.GetHolidayPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyEligiblesRepository.SetHolidayPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyEligiblesRepository.PostHolidayPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyEligiblesRepository.DelHolidayPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpHolidayPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _holidayPolicyEligiblesRepository.LookUpHolidayPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayPolicyEligibleViewModel> GetInfoHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyEligiblesRepository.GetInfoHolidayPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayPolicyEligibleViewModel> PrintHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _holidayPolicyEligiblesRepository.PrintHolidayPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPolicyEligiblesRepository.ApproveHolidayPolicyEligiblesAsync(common);
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
