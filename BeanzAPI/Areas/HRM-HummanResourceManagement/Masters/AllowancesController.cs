using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AllowancesController : ControllerBase
    {
        private readonly IAllowanceRepository _allowancesRepository;

        public AllowancesController(IAllowanceRepository allowancesRepository)
        {
            _allowancesRepository = allowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowanceDTO>> GetAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesRepository.GetAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesRepository.SetAllowancesAsync(common);
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
        public async Task<ActionResult> PostAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesRepository.PostAllowancesAsync(common);
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
        public async Task<ActionResult> DelAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesRepository.DelAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowances(BeanzCommonDTO lookup)
        {
            var data = await _allowancesRepository.LookUpAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowanceViewModel> GetInfoAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesRepository.GetInfoAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowanceViewModel> PrintAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesRepository.PrintAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesRepository.ApproveAllowancesAsync(common);
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
