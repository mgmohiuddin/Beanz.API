using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Accounts
{
    [Route("api/[area]/Accounts/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class ChartOfAccountCodeSettingsController : ControllerBase
    {
        private readonly IChartOfAccountCodeSettingBusiness _chartOfAccountCodeSettingsBusiness;

        public ChartOfAccountCodeSettingsController(IChartOfAccountCodeSettingBusiness chartOfAccountCodeSettingsBusiness)
        {
            _chartOfAccountCodeSettingsBusiness = chartOfAccountCodeSettingsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<ChartOfAccountCodeSettingDTO>> GetChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountCodeSettingsBusiness.GetChartOfAccountCodeSettingsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountCodeSettingsBusiness.SetChartOfAccountCodeSettingsAsync(common);
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
        public async Task<ActionResult> PostChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountCodeSettingsBusiness.PostChartOfAccountCodeSettingsAsync(common);
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
        public async Task<ActionResult> DelChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountCodeSettingsBusiness.DelChartOfAccountCodeSettingsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpChartOfAccountCodeSettings(BeanzCommonDTO lookup)
        {
            var data = await _chartOfAccountCodeSettingsBusiness.LookUpChartOfAccountCodeSettingsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ChartOfAccountCodeSettingViewModel> GetInfoChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountCodeSettingsBusiness.GetInfoChartOfAccountCodeSettingsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ChartOfAccountCodeSettingViewModel> PrintChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            var data = await _chartOfAccountCodeSettingsBusiness.PrintChartOfAccountCodeSettingsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveChartOfAccountCodeSettings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _chartOfAccountCodeSettingsBusiness.ApproveChartOfAccountCodeSettingsAsync(common);
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
