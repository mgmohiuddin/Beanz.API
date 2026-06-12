using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Accounts
{
    public interface IChartOfAccountCodeSettingRepository
    {
        Task<List<ChartOfAccountCodeSettingDTO>> GetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpChartOfAccountCodeSettingsAsync(BeanzCommonDTO lookup);
        Task<ChartOfAccountCodeSettingViewModel> GetInfoChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<ChartOfAccountCodeSettingViewModel> PrintChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveChartOfAccountCodeSettingsAsync(BeanzCommonDTO common);
    }
}
