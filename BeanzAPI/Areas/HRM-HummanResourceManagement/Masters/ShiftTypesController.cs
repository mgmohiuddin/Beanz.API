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
    public class ShiftTypesController : ControllerBase
    {
        private readonly IShiftTypeRepository _shiftTypesRepository;

        public ShiftTypesController(IShiftTypeRepository shiftTypesRepository)
        {
            _shiftTypesRepository = shiftTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<ShiftTypeDTO>> GetShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesRepository.GetShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesRepository.SetShiftTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesRepository.PostShiftTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesRepository.DelShiftTypesAsync(common);
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
            var data = await _shiftTypesRepository.LookUpShiftTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ShiftTypeViewModel> GetInfoShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesRepository.GetInfoShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ShiftTypeViewModel> PrintShiftTypes(BeanzCommonDTO common)
        {
            var data = await _shiftTypesRepository.PrintShiftTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveShiftTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftTypesRepository.ApproveShiftTypesAsync(common);
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
