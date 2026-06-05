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
    public class PermitTypesController : ControllerBase
    {
        private readonly IPermitTypeRepository _permitTypesRepository;

        public PermitTypesController(IPermitTypeRepository permitTypesRepository)
        {
            _permitTypesRepository = permitTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PermitTypeDTO>> GetPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesRepository.GetPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesRepository.SetPermitTypesAsync(common);
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
        public async Task<ActionResult> PostPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesRepository.PostPermitTypesAsync(common);
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
        public async Task<ActionResult> DelPermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesRepository.DelPermitTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPermitTypes(BeanzCommonDTO lookup)
        {
            var data = await _permitTypesRepository.LookUpPermitTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PermitTypeViewModel> GetInfoPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesRepository.GetInfoPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PermitTypeViewModel> PrintPermitTypes(BeanzCommonDTO common)
        {
            var data = await _permitTypesRepository.PrintPermitTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePermitTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _permitTypesRepository.ApprovePermitTypesAsync(common);
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
