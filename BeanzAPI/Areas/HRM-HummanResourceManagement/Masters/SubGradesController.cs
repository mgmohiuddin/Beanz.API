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
    public class SubGradesController : ControllerBase
    {
        private readonly ISubGradeBusiness _subGradesBusiness;

        public SubGradesController(ISubGradeBusiness subGradesBusiness)
        {
            _subGradesBusiness = subGradesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<SubGradeDTO>> GetSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesBusiness.GetSubGradesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesBusiness.SetSubGradesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _subGradesBusiness.PostSubGradesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _subGradesBusiness.DelSubGradesAsync(common);
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
            var data = await _subGradesBusiness.LookUpSubGradesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SubGradeViewModel> GetInfoSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesBusiness.GetInfoSubGradesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SubGradeViewModel> PrintSubGrades(BeanzCommonDTO common)
        {
            var data = await _subGradesBusiness.PrintSubGradesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSubGrades(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _subGradesBusiness.ApproveSubGradesAsync(common);
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
