using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class AllowancesController : ControllerBase
    {
        private readonly IAllowanceBusiness _allowancesBusiness;

        public AllowancesController(IAllowanceBusiness allowancesBusiness)
        {
            _allowancesBusiness = allowancesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AllowanceDTO>> GetAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesBusiness.GetAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesBusiness.SetAllowancesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _allowancesBusiness.PostAllowancesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _allowancesBusiness.DelAllowancesAsync(common);
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
            var data = await _allowancesBusiness.LookUpAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowanceViewModel> GetInfoAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesBusiness.GetInfoAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowanceViewModel> PrintAllowances(BeanzCommonDTO common)
        {
            var data = await _allowancesBusiness.PrintAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesBusiness.ApproveAllowancesAsync(common);
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
