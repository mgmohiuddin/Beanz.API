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
    public class HolidayTypesController : ControllerBase
    {
        private readonly IHolidayTypeBusiness _holidayTypesBusiness;

        public HolidayTypesController(IHolidayTypeBusiness holidayTypesBusiness)
        {
            _holidayTypesBusiness = holidayTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<HolidayTypeDTO>> GetHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesBusiness.GetHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesBusiness.SetHolidayTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesBusiness.PostHolidayTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesBusiness.DelHolidayTypesAsync(common);
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
            var data = await _holidayTypesBusiness.LookUpHolidayTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<HolidayTypeViewModel> GetInfoHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesBusiness.GetInfoHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<HolidayTypeViewModel> PrintHolidayTypes(BeanzCommonDTO common)
        {
            var data = await _holidayTypesBusiness.PrintHolidayTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveHolidayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _holidayTypesBusiness.ApproveHolidayTypesAsync(common);
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
