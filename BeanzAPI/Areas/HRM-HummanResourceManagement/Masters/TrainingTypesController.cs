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
    public class TrainingTypesController : ControllerBase
    {
        private readonly ITrainingTypeRepository _trainingTypesRepository;

        public TrainingTypesController(ITrainingTypeRepository trainingTypesRepository)
        {
            _trainingTypesRepository = trainingTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TrainingTypeDTO>> GetTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesRepository.GetTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesRepository.SetTrainingTypesAsync(common);
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
        public async Task<ActionResult> PostTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesRepository.PostTrainingTypesAsync(common);
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
        public async Task<ActionResult> DelTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesRepository.DelTrainingTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTrainingTypes(BeanzCommonDTO lookup)
        {
            var data = await _trainingTypesRepository.LookUpTrainingTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TrainingTypeViewModel> GetInfoTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesRepository.GetInfoTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TrainingTypeViewModel> PrintTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesRepository.PrintTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesRepository.ApproveTrainingTypesAsync(common);
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
