using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAccountOpeningDetailRepository
    {
        Task<List<AccountOpeningDetailDTO>> GetAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountOpeningDetailsAsync(BeanzCommonDTO lookup);
        Task<AccountOpeningDetailViewModel> GetInfoAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<AccountOpeningDetailViewModel> PrintAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountOpeningDetailsAsync(BeanzCommonDTO common);
    }
}
