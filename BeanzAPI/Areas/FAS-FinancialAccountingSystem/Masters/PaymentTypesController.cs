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
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeBusiness _paymentTypesBusiness;

        public PaymentTypesController(IPaymentTypeBusiness paymentTypesBusiness)
        {
            _paymentTypesBusiness = paymentTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<PaymentTypeDTO>> GetPaymentTypes(BeanzCommonDTO common)
        {
            var data = await _paymentTypesBusiness.GetPaymentTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPaymentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paymentTypesBusiness.SetPaymentTypesAsync(common);
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
        public async Task<ActionResult> PostPaymentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paymentTypesBusiness.PostPaymentTypesAsync(common);
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
        public async Task<ActionResult> DelPaymentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paymentTypesBusiness.DelPaymentTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPaymentTypes(BeanzCommonDTO lookup)
        {
            var data = await _paymentTypesBusiness.LookUpPaymentTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PaymentTypeViewModel> GetInfoPaymentTypes(BeanzCommonDTO common)
        {
            var data = await _paymentTypesBusiness.GetInfoPaymentTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PaymentTypeViewModel> PrintPaymentTypes(BeanzCommonDTO common)
        {
            var data = await _paymentTypesBusiness.PrintPaymentTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePaymentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _paymentTypesBusiness.ApprovePaymentTypesAsync(common);
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
