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
    public class WorkProfessionsController : ControllerBase
    {
        private readonly IWorkProfessionRepository _workProfessionsRepository;

        public WorkProfessionsController(IWorkProfessionRepository workProfessionsRepository)
        {
            _workProfessionsRepository = workProfessionsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<WorkProfessionDTO>> GetWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsRepository.GetWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsRepository.SetWorkProfessionsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsRepository.PostWorkProfessionsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsRepository.DelWorkProfessionsAsync(common);
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
            var data = await _workProfessionsRepository.LookUpWorkProfessionsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<WorkProfessionViewModel> GetInfoWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsRepository.GetInfoWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<WorkProfessionViewModel> PrintWorkProfessions(BeanzCommonDTO common)
        {
            var data = await _workProfessionsRepository.PrintWorkProfessionsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveWorkProfessions(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _workProfessionsRepository.ApproveWorkProfessionsAsync(common);
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
