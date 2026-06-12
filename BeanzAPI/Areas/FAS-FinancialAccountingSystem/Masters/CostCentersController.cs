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
    public class CostCentersController : ControllerBase
    {
        private readonly ICostCenterBusiness _costCentersBusiness;

        public CostCentersController(ICostCenterBusiness costCentersBusiness)
        {
            _costCentersBusiness = costCentersBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<CostCenterDTO>> GetCostCenters(BeanzCommonDTO common)
        {
            var data = await _costCentersBusiness.GetCostCentersAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetCostCenters(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _costCentersBusiness.SetCostCentersAsync(common);
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
        public async Task<ActionResult> PostCostCenters(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _costCentersBusiness.PostCostCentersAsync(common);
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
        public async Task<ActionResult> DelCostCenters(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _costCentersBusiness.DelCostCentersAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpCostCenters(BeanzCommonDTO lookup)
        {
            var data = await _costCentersBusiness.LookUpCostCentersAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<CostCenterViewModel> GetInfoCostCenters(BeanzCommonDTO common)
        {
            var data = await _costCentersBusiness.GetInfoCostCentersAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<CostCenterViewModel> PrintCostCenters(BeanzCommonDTO common)
        {
            var data = await _costCentersBusiness.PrintCostCentersAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveCostCenters(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _costCentersBusiness.ApproveCostCentersAsync(common);
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
