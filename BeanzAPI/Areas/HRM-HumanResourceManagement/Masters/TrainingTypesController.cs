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
    public class TrainingTypesController : ControllerBase
    {
        private readonly ITrainingTypeBusiness _trainingTypesBusiness;

        public TrainingTypesController(ITrainingTypeBusiness trainingTypesBusiness)
        {
            _trainingTypesBusiness = trainingTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<TrainingTypeDTO>> GetTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesBusiness.GetTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesBusiness.SetTrainingTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesBusiness.PostTrainingTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesBusiness.DelTrainingTypesAsync(common);
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
            var data = await _trainingTypesBusiness.LookUpTrainingTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TrainingTypeViewModel> GetInfoTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesBusiness.GetInfoTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TrainingTypeViewModel> PrintTrainingTypes(BeanzCommonDTO common)
        {
            var data = await _trainingTypesBusiness.PrintTrainingTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTrainingTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingTypesBusiness.ApproveTrainingTypesAsync(common);
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
