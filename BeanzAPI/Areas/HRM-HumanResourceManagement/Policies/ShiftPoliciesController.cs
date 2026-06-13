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
    public class ShiftPoliciesController : ControllerBase
    {
        private readonly IShiftPolicieRepository _shiftPoliciesRepository;

        public ShiftPoliciesController(IShiftPolicieRepository shiftPoliciesRepository)
        {
            _shiftPoliciesRepository = shiftPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<ShiftPolicieDTO>> GetShiftPolicies(BeanzCommonDTO common)
        {
            var data = await _shiftPoliciesRepository.GetShiftPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetShiftPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPoliciesRepository.SetShiftPoliciesAsync(common);
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
        public async Task<ActionResult> PostShiftPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPoliciesRepository.PostShiftPoliciesAsync(common);
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
        public async Task<ActionResult> DelShiftPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPoliciesRepository.DelShiftPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpShiftPolicies(BeanzCommonDTO lookup)
        {
            var data = await _shiftPoliciesRepository.LookUpShiftPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ShiftPolicieViewModel> GetInfoShiftPolicies(BeanzCommonDTO common)
        {
            var data = await _shiftPoliciesRepository.GetInfoShiftPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ShiftPolicieViewModel> PrintShiftPolicies(BeanzCommonDTO common)
        {
            var data = await _shiftPoliciesRepository.PrintShiftPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveShiftPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _shiftPoliciesRepository.ApproveShiftPoliciesAsync(common);
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
