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
    public class PositionsController : ControllerBase
    {
        private readonly IPositionBusiness _positionsBusiness;

        public PositionsController(IPositionBusiness positionsBusiness)
        {
            _positionsBusiness = positionsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<PositionDTO>> GetPositions(BeanzCommonDTO common)
        {
            var data = await _positionsBusiness.GetPositionsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsBusiness.SetPositionsAsync(common);
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
        public async Task<ActionResult> PostPositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsBusiness.PostPositionsAsync(common);
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
        public async Task<ActionResult> DelPositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsBusiness.DelPositionsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPositions(BeanzCommonDTO lookup)
        {
            var data = await _positionsBusiness.LookUpPositionsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PositionViewModel> GetInfoPositions(BeanzCommonDTO common)
        {
            var data = await _positionsBusiness.GetInfoPositionsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PositionViewModel> PrintPositions(BeanzCommonDTO common)
        {
            var data = await _positionsBusiness.PrintPositionsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsBusiness.ApprovePositionsAsync(common);
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
