using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Accounts
{
    [Route("api/[area]/Accounts/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class ChartOfAccountsController : ControllerBase
    {
        private readonly IChartOfAccountBusiness _chartOfAccountsBusiness;

        public ChartOfAccountsController(IChartOfAccountBusiness chartOfAccountsBusiness)
        {
            _chartOfAccountsBusiness = chartOfAccountsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<ChartOfAccountDTO>> GetChartOfAccounts(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountsBusiness.GetChartOfAccountsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetChartOfAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountsBusiness.SetChartOfAccountsAsync(common);
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
        public async Task<ActionResult> PostChartOfAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountsBusiness.PostChartOfAccountsAsync(common);
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
        public async Task<ActionResult> DelChartOfAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountsBusiness.DelChartOfAccountsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpChartOfAccounts(BeanzCommonDTO lookup)
        {
            var data = await _chartOfAccountsBusiness.LookUpChartOfAccountsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ChartOfAccountViewModel> GetInfoChartOfAccounts(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountsBusiness.GetInfoChartOfAccountsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ChartOfAccountViewModel> PrintChartOfAccounts(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountsBusiness.PrintChartOfAccountsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveChartOfAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountsBusiness.ApproveChartOfAccountsAsync(common);
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
