using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts
{
    public interface IChartOfAccountBusiness
    {
        Task<List<ChartOfAccountDTO>> GetChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelChartOfAccountsAsync(BeanzCommonDTO common);
        Task<ChartOfAccountViewModel> GetInfoChartOfAccountsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpChartOfAccountsAsync(BeanzCommonDTO lookup);
        Task<ChartOfAccountViewModel> PrintChartOfAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveChartOfAccountsAsync(BeanzCommonDTO common);
    }
}
