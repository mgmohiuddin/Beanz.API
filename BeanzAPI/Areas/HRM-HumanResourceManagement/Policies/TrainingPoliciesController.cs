using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class TrainingPoliciesController : ControllerBase
    {
        private readonly ITrainingPolicieRepository _trainingPoliciesRepository;

        public TrainingPoliciesController(ITrainingPolicieRepository trainingPoliciesRepository)
        {
            _trainingPoliciesRepository = trainingPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TrainingPolicieDTO>> GetTrainingPolicies(BeanzCommonDTO common)
        {
            var data = await _trainingPoliciesRepository.GetTrainingPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTrainingPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPoliciesRepository.SetTrainingPoliciesAsync(common);
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
        public async Task<ActionResult> PostTrainingPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPoliciesRepository.PostTrainingPoliciesAsync(common);
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
        public async Task<ActionResult> DelTrainingPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPoliciesRepository.DelTrainingPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTrainingPolicies(BeanzCommonDTO lookup)
        {
            var data = await _trainingPoliciesRepository.LookUpTrainingPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TrainingPolicieViewModel> GetInfoTrainingPolicies(BeanzCommonDTO common)
        {
            var data = await _trainingPoliciesRepository.GetInfoTrainingPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TrainingPolicieViewModel> PrintTrainingPolicies(BeanzCommonDTO common)
        {
            var data = await _trainingPoliciesRepository.PrintTrainingPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTrainingPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPoliciesRepository.ApproveTrainingPoliciesAsync(common);
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
