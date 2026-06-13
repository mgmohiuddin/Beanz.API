using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts
{
    public interface IAccountTypeBusiness
    {
        Task<List<AccountTypeDTO>> GetAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountTypesAsync(BeanzCommonDTO common);
        Task<AccountTypeViewModel> GetInfoAccountTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountTypesAsync(BeanzCommonDTO lookup);
        Task<AccountTypeViewModel> PrintAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountTypesAsync(BeanzCommonDTO common);
    }
}
