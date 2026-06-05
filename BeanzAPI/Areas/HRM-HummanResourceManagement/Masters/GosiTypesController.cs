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
    public class GosiTypesController : ControllerBase
    {
        private readonly IGosiTypeRepository _gosiTypesRepository;

        public GosiTypesController(IGosiTypeRepository gosiTypesRepository)
        {
            _gosiTypesRepository = gosiTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GosiTypeDTO>> GetGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesRepository.GetGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesRepository.SetGosiTypesAsync(common);
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
        public async Task<ActionResult> PostGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesRepository.PostGosiTypesAsync(common);
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
        public async Task<ActionResult> DelGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesRepository.DelGosiTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGosiTypes(BeanzCommonDTO lookup)
        {
            var data = await _gosiTypesRepository.LookUpGosiTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiTypeViewModel> GetInfoGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesRepository.GetInfoGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiTypeViewModel> PrintGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesRepository.PrintGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesRepository.ApproveGosiTypesAsync(common);
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
