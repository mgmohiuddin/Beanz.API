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
    public class HolidayPoliciesController : ControllerBase
    {
        private readonly IHolidayPolicieRepository _holidayPoliciesRepository;

        public HolidayPoliciesController(IHolidayPolicieRepository holidayPoliciesRepository)
        {
            _holidayPoliciesRepository = holidayPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayPolicieDTO>> GetHolidayPolicies(BeanzCommonDTO common)
        {
            var data = await _holidayPoliciesRepository.GetHolidayPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPoliciesRepository.SetHolidayPoliciesAsync(common);
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
        public async Task<ActionResult> PostHolidayPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPoliciesRepository.PostHolidayPoliciesAsync(common);
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
        public async Task<ActionResult> DelHolidayPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPoliciesRepository.DelHolidayPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpHolidayPolicies(BeanzCommonDTO lookup)
        {
            var data = await _holidayPoliciesRepository.LookUpHolidayPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayPolicieViewModel> GetInfoHolidayPolicies(BeanzCommonDTO common)
        {
            var data = await _holidayPoliciesRepository.GetInfoHolidayPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayPolicieViewModel> PrintHolidayPolicies(BeanzCommonDTO common)
        {
            var data = await _holidayPoliciesRepository.PrintHolidayPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayPoliciesRepository.ApproveHolidayPoliciesAsync(common);
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
