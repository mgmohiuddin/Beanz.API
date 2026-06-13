using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class ShiftTypesController : ControllerBase
    {
        private readonly IShiftTypeBusiness _shiftTypesBusiness;

        public ShiftTypesController(IShiftTypeBusiness shiftTypesBusiness)
        {
            _shiftTypesBusiness = shiftTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<ShiftTypeDTO>> GetShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesBusiness.GetShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesBusiness.SetShiftTypesAsync(common);
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
        public async Task<ActionResult> PostShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesBusiness.PostShiftTypesAsync(common);
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
        public async Task<ActionResult> DelShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesBusiness.DelShiftTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpShiftTypes(BeanzCommonDTO lookup)
        {
            var data = await _shiftTypesBusiness.LookUpShiftTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ShiftTypeViewModel> GetInfoShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesBusiness.GetInfoShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ShiftTypeViewModel> PrintShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesBusiness.PrintShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesBusiness.ApproveShiftTypesAsync(common);
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
