using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts
{
    public interface IChartOfAccountCodeSettingBusiness
    {
        Task<List<ChartOfAccountCodeSettingDTO>> GetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<ChartOfAccountCodeSettingViewModel> GetInfoChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpChartOfAccountCodeSettingsAsync(BeanzCommonDTO lookup);
        Task<ChartOfAccountCodeSettingViewModel> PrintChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
    }
}
