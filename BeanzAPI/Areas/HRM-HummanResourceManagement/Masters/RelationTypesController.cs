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
    public class RelationTypesController : ControllerBase
    {
        private readonly IRelationTypeBusiness _relationTypesBusiness;

        public RelationTypesController(IRelationTypeBusiness relationTypesBusiness)
        {
            _relationTypesBusiness = relationTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<RelationTypeDTO>> GetRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesBusiness.GetRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesBusiness.SetRelationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _relationTypesBusiness.PostRelationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _relationTypesBusiness.DelRelationTypesAsync(common);
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
            var data = await _relationTypesBusiness.LookUpRelationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<RelationTypeViewModel> GetInfoRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesBusiness.GetInfoRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<RelationTypeViewModel> PrintRelationTypes(BeanzCommonDTO common)
        {
            var data = await _relationTypesBusiness.PrintRelationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveRelationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _relationTypesBusiness.ApproveRelationTypesAsync(common);
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
