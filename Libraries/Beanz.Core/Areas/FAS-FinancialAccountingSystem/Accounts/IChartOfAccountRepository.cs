using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Accounts
{
    public interface IChartOfAccountRepository
    {
        Task<List<ChartOfAccountDTO>> GetChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelChartOfAccountsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpChartOfAccountsAsync(BeanzCommonDTO lookup);
        Task<ChartOfAccountViewModel> GetInfoChartOfAccountsAsync(BeanzCommonDTO common);
        Task<ChartOfAccountViewModel> PrintChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveChartOfAccountsAsync(BeanzCommonDTO common);
    }
}
