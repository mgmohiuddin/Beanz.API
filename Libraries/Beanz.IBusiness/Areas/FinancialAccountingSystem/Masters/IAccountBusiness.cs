using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface IAccountBusiness
    {
        Task<List<AccountDTO>> GetAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountsAsync(BeanzCommonDTO common);
        Task<AccountViewModel> GetInfoAccountsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountsAsync(BeanzCommonDTO lookup);
        Task<AccountViewModel> PrintAccountsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountsAsync(BeanzCommonDTO common);
    }
}
