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
    public class RelationTypesController : ControllerBase
    {
        private readonly IRelationTypeRepository _relationTypesRepository;

        public RelationTypesController(IRelationTypeRepository relationTypesRepository)
        {
            _relationTypesRepository = relationTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<RelationTypeDTO>> GetRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesRepository.GetRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesRepository.SetRelationTypesAsync(common);
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
        public async Task<ActionResult> PostRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesRepository.PostRelationTypesAsync(common);
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
        public async Task<ActionResult> DelRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesRepository.DelRelationTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpRelationTypes(BeanzCommonDTO lookup)
        {
            var data = await _relationTypesRepository.LookUpRelationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<RelationTypeViewModel> GetInfoRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesRepository.GetInfoRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<RelationTypeViewModel> PrintRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesRepository.PrintRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesRepository.ApproveRelationTypesAsync(common);
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
