using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface IAccountRepository
    {
        Task<List<AccountDTO>> GetAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountsAsync(BeanzCommonDTO lookup);
        Task<AccountViewModel> GetInfoAccountsAsync(BeanzCommonDTO common);
        Task<AccountViewModel> PrintAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountsAsync(BeanzCommonDTO common);
    }
}
