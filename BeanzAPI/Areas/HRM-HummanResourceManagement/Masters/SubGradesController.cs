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
    public class SubGradesController : ControllerBase
    {
        private readonly ISubGradeRepository _subGradesRepository;

        public SubGradesController(ISubGradeRepository subGradesRepository)
        {
            _subGradesRepository = subGradesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<SubGradeDTO>> GetSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesRepository.GetSubGradesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesRepository.SetSubGradesAsync(common);
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
        public async Task<ActionResult> PostSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesRepository.PostSubGradesAsync(common);
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
        public async Task<ActionResult> DelSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesRepository.DelSubGradesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpSubGrades(BeanzCommonDTO lookup)
        {
            var data = await _subGradesRepository.LookUpSubGradesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SubGradeViewModel> GetInfoSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesRepository.GetInfoSubGradesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SubGradeViewModel> PrintSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesRepository.PrintSubGradesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesRepository.ApproveSubGradesAsync(common);
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
