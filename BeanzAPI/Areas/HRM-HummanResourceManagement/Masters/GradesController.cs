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
    public class GradesController : ControllerBase
    {
        private readonly IGradeRepository _gradesRepository;

        public GradesController(IGradeRepository gradesRepository)
        {
            _gradesRepository = gradesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GradeDTO>> GetGrades(BeanzCommonDTO common)
        {
            var data = await _gradesRepository.GetGradesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesRepository.SetGradesAsync(common);
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
        public async Task<ActionResult> PostGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesRepository.PostGradesAsync(common);
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
        public async Task<ActionResult> DelGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesRepository.DelGradesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGrades(BeanzCommonDTO lookup)
        {
            var data = await _gradesRepository.LookUpGradesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GradeViewModel> GetInfoGrades(BeanzCommonDTO common)
        {
            var data = await _gradesRepository.GetInfoGradesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GradeViewModel> PrintGrades(BeanzCommonDTO common)
        {
            var data = await _gradesRepository.PrintGradesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesRepository.ApproveGradesAsync(common);
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
