using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class PaidTimeOffTypesController : ControllerBase
    {
        private readonly IPaidTimeOffTypeBusiness _paidTimeOffTypesBusiness;

        public PaidTimeOffTypesController(IPaidTimeOffTypeBusiness paidTimeOffTypesBusiness)
        {
            _paidTimeOffTypesBusiness = paidTimeOffTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<PaidTimeOffTypeDTO>> GetPaidTimeOffTypes(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffTypesBusiness.GetPaidTimeOffTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPaidTimeOffTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffTypesBusiness.SetPaidTimeOffTypesAsync(common);
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
        public async Task<ActionResult> PostPaidTimeOffTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffTypesBusiness.PostPaidTimeOffTypesAsync(common);
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
        public async Task<ActionResult> DelPaidTimeOffTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffTypesBusiness.DelPaidTimeOffTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPaidTimeOffTypes(BeanzCommonDTO lookup)
        {
            var data = await _paidTimeOffTypesBusiness.LookUpPaidTimeOffTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PaidTimeOffTypeViewModel> GetInfoPaidTimeOffTypes(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffTypesBusiness.GetInfoPaidTimeOffTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PaidTimeOffTypeViewModel> PrintPaidTimeOffTypes(BeanzCommonDTO common)
        {
            var data = await _paidTimeOffTypesBusiness.PrintPaidTimeOffTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePaidTimeOffTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paidTimeOffTypesBusiness.ApprovePaidTimeOffTypesAsync(common);
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
