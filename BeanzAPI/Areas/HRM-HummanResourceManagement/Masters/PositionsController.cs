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
    public class PositionsController : ControllerBase
    {
        private readonly IPositionRepository _positionsRepository;

        public PositionsController(IPositionRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PositionDTO>> GetPositions(BeanzCommonDTO common)
        {
            var data = await _positionsRepository.GetPositionsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsRepository.SetPositionsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _positionsRepository.PostPositionsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _positionsRepository.DelPositionsAsync(common);
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
            var data = await _positionsRepository.LookUpPositionsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PositionViewModel> GetInfoPositions(BeanzCommonDTO common)
        {
            var data = await _positionsRepository.GetInfoPositionsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PositionViewModel> PrintPositions(BeanzCommonDTO common)
        {
            var data = await _positionsRepository.PrintPositionsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePositions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _positionsRepository.ApprovePositionsAsync(common);
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
