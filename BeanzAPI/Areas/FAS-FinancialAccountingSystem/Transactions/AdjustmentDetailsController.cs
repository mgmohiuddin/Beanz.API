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
    public class AdjustmentDetailsController : ControllerBase
    {
        private readonly IAdjustmentDetailBusiness _adjustmentDetailsBusiness;

        public AdjustmentDetailsController(IAdjustmentDetailBusiness adjustmentDetailsBusiness)
        {
            _adjustmentDetailsBusiness = adjustmentDetailsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AdjustmentDetailDTO>> GetAdjustmentDetails(BeanzCommonDTO common)
        {
            var data = await _adjustmentDetailsBusiness.GetAdjustmentDetailsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdjustmentDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentDetailsBusiness.SetAdjustmentDetailsAsync(common);
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
        public async Task<ActionResult> PostAdjustmentDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentDetailsBusiness.PostAdjustmentDetailsAsync(common);
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
        public async Task<ActionResult> DelAdjustmentDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentDetailsBusiness.DelAdjustmentDetailsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdjustmentDetails(BeanzCommonDTO lookup)
        {
            var data = await _adjustmentDetailsBusiness.LookUpAdjustmentDetailsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdjustmentDetailViewModel> GetInfoAdjustmentDetails(BeanzCommonDTO common)
        {
            var data = await _adjustmentDetailsBusiness.GetInfoAdjustmentDetailsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdjustmentDetailViewModel> PrintAdjustmentDetails(BeanzCommonDTO common)
        {
            var data = await _adjustmentDetailsBusiness.PrintAdjustmentDetailsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdjustmentDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _adjustmentDetailsBusiness.ApproveAdjustmentDetailsAsync(common);
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
