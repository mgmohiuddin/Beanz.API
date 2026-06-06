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
    public class OvertimePolicyEligiblesController : ControllerBase
    {
        private readonly IOvertimePolicyEligibleRepository _overtimePolicyEligiblesRepository;

        public OvertimePolicyEligiblesController(IOvertimePolicyEligibleRepository overtimePolicyEligiblesRepository)
        {
            _overtimePolicyEligiblesRepository = overtimePolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<OvertimePolicyEligibleDTO>> GetOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyEligiblesRepository.GetOvertimePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyEligiblesRepository.SetOvertimePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyEligiblesRepository.PostOvertimePolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyEligiblesRepository.DelOvertimePolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpOvertimePolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _overtimePolicyEligiblesRepository.LookUpOvertimePolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<OvertimePolicyEligibleViewModel> GetInfoOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyEligiblesRepository.GetInfoOvertimePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<OvertimePolicyEligibleViewModel> PrintOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _overtimePolicyEligiblesRepository.PrintOvertimePolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveOvertimePolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _overtimePolicyEligiblesRepository.ApproveOvertimePolicyEligiblesAsync(common);
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
