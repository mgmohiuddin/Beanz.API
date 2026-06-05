using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class TrainingPolicyEligiblesController : ControllerBase
    {
        private readonly ITrainingPolicyEligibleRepository _trainingPolicyEligiblesRepository;

        public TrainingPolicyEligiblesController(ITrainingPolicyEligibleRepository trainingPolicyEligiblesRepository)
        {
            _trainingPolicyEligiblesRepository = trainingPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TrainingPolicyEligibleDTO>> GetTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _trainingPolicyEligiblesRepository.GetTrainingPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPolicyEligiblesRepository.SetTrainingPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPolicyEligiblesRepository.PostTrainingPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPolicyEligiblesRepository.DelTrainingPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTrainingPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _trainingPolicyEligiblesRepository.LookUpTrainingPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TrainingPolicyEligibleViewModel> GetInfoTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _trainingPolicyEligiblesRepository.GetInfoTrainingPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TrainingPolicyEligibleViewModel> PrintTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _trainingPolicyEligiblesRepository.PrintTrainingPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTrainingPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _trainingPolicyEligiblesRepository.ApproveTrainingPolicyEligiblesAsync(common);
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
