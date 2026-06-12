using Beanz.Core.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Transactions
{
    [Route("api/[area]/Transactions/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class AdjustmentsController : ControllerBase
    {
        private readonly IAdjustmentBusiness _adjustmentsBusiness;

        public AdjustmentsController(IAdjustmentBusiness adjustmentsBusiness)
        {
            _adjustmentsBusiness = adjustmentsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AdjustmentDTO>> GetAdjustments(BeanzCommonDTO common)
        {
            var data = await _adjustmentsBusiness.GetAdjustmentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdjustments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentsBusiness.SetAdjustmentsAsync(common);
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
        public async Task<ActionResult> PostAdjustments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentsBusiness.PostAdjustmentsAsync(common);
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
        public async Task<ActionResult> DelAdjustments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentsBusiness.DelAdjustmentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdjustments(BeanzCommonDTO lookup)
        {
            var data = await _adjustmentsBusiness.LookUpAdjustmentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdjustmentViewModel> GetInfoAdjustments(BeanzCommonDTO common)
        {
            var data = await _adjustmentsBusiness.GetInfoAdjustmentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdjustmentViewModel> PrintAdjustments(BeanzCommonDTO common)
        {
            var data = await _adjustmentsBusiness.PrintAdjustmentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdjustments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentsBusiness.ApproveAdjustmentsAsync(common);
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
