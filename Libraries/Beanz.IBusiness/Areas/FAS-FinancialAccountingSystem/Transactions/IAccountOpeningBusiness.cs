using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAccountOpeningBusiness
    {
        Task<List<AccountOpeningDTO>> GetAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountOpeningsAsync(BeanzCommonDTO common);
        Task<AccountOpeningViewModel> GetInfoAccountOpeningsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountOpeningsAsync(BeanzCommonDTO lookup);
        Task<AccountOpeningViewModel> PrintAccountOpeningsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountOpeningsAsync(BeanzCommonDTO common);
    }
}
