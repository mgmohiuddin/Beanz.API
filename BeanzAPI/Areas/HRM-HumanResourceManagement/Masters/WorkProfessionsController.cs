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
    public class WorkProfessionsController : ControllerBase
    {
        private readonly IWorkProfessionBusiness _workProfessionsBusiness;

        public WorkProfessionsController(IWorkProfessionBusiness workProfessionsBusiness)
        {
            _workProfessionsBusiness = workProfessionsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<WorkProfessionDTO>> GetWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsBusiness.GetWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsBusiness.SetWorkProfessionsAsync(common);
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
        public async Task<ActionResult> PostWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsBusiness.PostWorkProfessionsAsync(common);
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
        public async Task<ActionResult> DelWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsBusiness.DelWorkProfessionsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpWorkProfessions(BeanzCommonDTO lookup)
        {
            var data = await _workProfessionsBusiness.LookUpWorkProfessionsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<WorkProfessionViewModel> GetInfoWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsBusiness.GetInfoWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<WorkProfessionViewModel> PrintWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsBusiness.PrintWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsBusiness.ApproveWorkProfessionsAsync(common);
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
