using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Accounts
{
    public interface IAccountTypeRepository
    {
        Task<List<AccountTypeDTO>> GetAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountTypesAsync(BeanzCommonDTO lookup);
        Task<AccountTypeViewModel> GetInfoAccountTypesAsync(BeanzCommonDTO common);
        Task<AccountTypeViewModel> PrintAccountTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountTypesAsync(BeanzCommonDTO common);
    }
}
