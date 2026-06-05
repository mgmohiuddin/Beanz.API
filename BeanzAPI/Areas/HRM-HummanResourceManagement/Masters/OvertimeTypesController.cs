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
    public class OvertimeTypesController : ControllerBase
    {
        private readonly IOvertimeTypeRepository _overtimeTypesRepository;

        public OvertimeTypesController(IOvertimeTypeRepository overtimeTypesRepository)
        {
            _overtimeTypesRepository = overtimeTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<OvertimeTypeDTO>> GetOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesRepository.GetOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesRepository.SetOvertimeTypesAsync(common);
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
        public async Task<ActionResult> PostOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesRepository.PostOvertimeTypesAsync(common);
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
        public async Task<ActionResult> DelOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesRepository.DelOvertimeTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOvertimeTypes(BeanzCommonDTO lookup)
        {
            var data = await _overtimeTypesRepository.LookUpOvertimeTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OvertimeTypeViewModel> GetInfoOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesRepository.GetInfoOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OvertimeTypeViewModel> PrintOvertimeTypes(BeanzCommonDTO common)
        {
            var data = await _overtimeTypesRepository.PrintOvertimeTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOvertimeTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimeTypesRepository.ApproveOvertimeTypesAsync(common);
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
