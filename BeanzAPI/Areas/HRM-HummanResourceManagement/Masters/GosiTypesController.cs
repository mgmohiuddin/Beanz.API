using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class GosiTypesController : ControllerBase
    {
        private readonly IGosiTypeBusiness _gosiTypesBusiness;

        public GosiTypesController(IGosiTypeBusiness gosiTypesBusiness)
        {
            _gosiTypesBusiness = gosiTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<GosiTypeDTO>> GetGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesBusiness.GetGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesBusiness.SetGosiTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesBusiness.PostGosiTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesBusiness.DelGosiTypesAsync(common);
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
            var data = await _gosiTypesBusiness.LookUpGosiTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiTypeViewModel> GetInfoGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesBusiness.GetInfoGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiTypeViewModel> PrintGosiTypes(BeanzCommonDTO common)
        {
            var data = await _gosiTypesBusiness.PrintGosiTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiTypesBusiness.ApproveGosiTypesAsync(common);
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
