using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAccountOpeningRepository
    {
        Task<List<AccountOpeningDTO>> GetAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountOpeningsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountOpeningsAsync(BeanzCommonDTO lookup);
        Task<AccountOpeningViewModel> GetInfoAccountOpeningsAsync(BeanzCommonDTO common);
        Task<AccountOpeningViewModel> PrintAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountOpeningsAsync(BeanzCommonDTO common);
    }
}
