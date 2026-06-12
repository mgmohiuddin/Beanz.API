using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class VoucherTypesController : ControllerBase
    {
        private readonly IVoucherTypeBusiness _voucherTypesBusiness;

        public VoucherTypesController(IVoucherTypeBusiness voucherTypesBusiness)
        {
            _voucherTypesBusiness = voucherTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<VoucherTypeDTO>> GetVoucherTypes(BeanzCommonDTO common)
        {
            var data = await _voucherTypesBusiness.GetVoucherTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVoucherTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _voucherTypesBusiness.SetVoucherTypesAsync(common);
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
        public async Task<ActionResult> PostVoucherTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _voucherTypesBusiness.PostVoucherTypesAsync(common);
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
        public async Task<ActionResult> DelVoucherTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _voucherTypesBusiness.DelVoucherTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVoucherTypes(BeanzCommonDTO lookup)
        {
            var data = await _voucherTypesBusiness.LookUpVoucherTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VoucherTypeViewModel> GetInfoVoucherTypes(BeanzCommonDTO common)
        {
            var data = await _voucherTypesBusiness.GetInfoVoucherTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VoucherTypeViewModel> PrintVoucherTypes(BeanzCommonDTO common)
        {
            var data = await _voucherTypesBusiness.PrintVoucherTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVoucherTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _voucherTypesBusiness.ApproveVoucherTypesAsync(common);
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
