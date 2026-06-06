using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class VacationPolicyEligiblesController : ControllerBase
    {
        private readonly IVacationPolicyEligibleRepository _vacationPolicyEligiblesRepository;

        public VacationPolicyEligiblesController(IVacationPolicyEligibleRepository vacationPolicyEligiblesRepository)
        {
            _vacationPolicyEligiblesRepository = vacationPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<VacationPolicyEligibleDTO>> GetVacationPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyEligiblesRepository.GetVacationPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVacationPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyEligiblesRepository.SetVacationPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostVacationPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyEligiblesRepository.PostVacationPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelVacationPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyEligiblesRepository.DelVacationPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVacationPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _vacationPolicyEligiblesRepository.LookUpVacationPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VacationPolicyEligibleViewModel> GetInfoVacationPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyEligiblesRepository.GetInfoVacationPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VacationPolicyEligibleViewModel> PrintVacationPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyEligiblesRepository.PrintVacationPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVacationPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyEligiblesRepository.ApproveVacationPolicyEligiblesAsync(common);
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
