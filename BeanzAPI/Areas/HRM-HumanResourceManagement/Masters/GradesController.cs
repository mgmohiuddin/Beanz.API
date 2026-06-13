using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeBusiness _gradesBusiness;

        public GradesController(IGradeBusiness gradesBusiness)
        {
            _gradesBusiness = gradesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<GradeDTO>> GetGrades(BeanzCommonDTO common)
        {
            var data = await _gradesBusiness.GetGradesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesBusiness.SetGradesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _gradesBusiness.PostGradesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _gradesBusiness.DelGradesAsync(common);
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
            var data = await _gradesBusiness.LookUpGradesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GradeViewModel> GetInfoGrades(BeanzCommonDTO common)
        {
            var data = await _gradesBusiness.GetInfoGradesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GradeViewModel> PrintGrades(BeanzCommonDTO common)
        {
            var data = await _gradesBusiness.PrintGradesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gradesBusiness.ApproveGradesAsync(common);
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
