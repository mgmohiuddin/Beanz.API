using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class HolidayTypesController : ControllerBase
    {
        private readonly IHolidayTypeRepository _holidayTypesRepository;

        public HolidayTypesController(IHolidayTypeRepository holidayTypesRepository)
        {
            _holidayTypesRepository = holidayTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayTypeDTO>> GetHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesRepository.GetHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesRepository.SetHolidayTypesAsync(common);
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
        public async Task<ActionResult> PostHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesRepository.PostHolidayTypesAsync(common);
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
        public async Task<ActionResult> DelHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesRepository.DelHolidayTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpHolidayTypes(BeanzCommonDTO lookup)
        {
            var data = await _holidayTypesRepository.LookUpHolidayTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayTypeViewModel> GetInfoHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesRepository.GetInfoHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayTypeViewModel> PrintHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesRepository.PrintHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesRepository.ApproveHolidayTypesAsync(common);
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
