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
    public class ShiftPolicyEligiblesController : ControllerBase
    {
        private readonly IShiftPolicyEligibleRepository _shiftPolicyEligiblesRepository;

        public ShiftPolicyEligiblesController(IShiftPolicyEligibleRepository shiftPolicyEligiblesRepository)
        {
            _shiftPolicyEligiblesRepository = shiftPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<ShiftPolicyEligibleDTO>> GetShiftPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _shiftPolicyEligiblesRepository.GetShiftPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetShiftPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPolicyEligiblesRepository.SetShiftPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostShiftPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPolicyEligiblesRepository.PostShiftPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelShiftPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPolicyEligiblesRepository.DelShiftPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpShiftPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _shiftPolicyEligiblesRepository.LookUpShiftPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ShiftPolicyEligibleViewModel> GetInfoShiftPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _shiftPolicyEligiblesRepository.GetInfoShiftPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ShiftPolicyEligibleViewModel> PrintShiftPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _shiftPolicyEligiblesRepository.PrintShiftPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveShiftPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPolicyEligiblesRepository.ApproveShiftPolicyEligiblesAsync(common);
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
