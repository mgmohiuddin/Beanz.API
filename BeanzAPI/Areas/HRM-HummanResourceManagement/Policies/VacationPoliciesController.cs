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
    public class VacationPoliciesController : ControllerBase
    {
        private readonly IVacationPolicieRepository _vacationPoliciesRepository;

        public VacationPoliciesController(IVacationPolicieRepository vacationPoliciesRepository)
        {
            _vacationPoliciesRepository = vacationPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<VacationPolicieDTO>> GetVacationPolicies(BeanzCommonDTO common)
        {
            var data = await _vacationPoliciesRepository.GetVacationPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVacationPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPoliciesRepository.SetVacationPoliciesAsync(common);
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
        public async Task<ActionResult> PostVacationPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPoliciesRepository.PostVacationPoliciesAsync(common);
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
        public async Task<ActionResult> DelVacationPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPoliciesRepository.DelVacationPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVacationPolicies(BeanzCommonDTO lookup)
        {
            var data = await _vacationPoliciesRepository.LookUpVacationPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VacationPolicieViewModel> GetInfoVacationPolicies(BeanzCommonDTO common)
        {
            var data = await _vacationPoliciesRepository.GetInfoVacationPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VacationPolicieViewModel> PrintVacationPolicies(BeanzCommonDTO common)
        {
            var data = await _vacationPoliciesRepository.PrintVacationPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVacationPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPoliciesRepository.ApproveVacationPoliciesAsync(common);
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
