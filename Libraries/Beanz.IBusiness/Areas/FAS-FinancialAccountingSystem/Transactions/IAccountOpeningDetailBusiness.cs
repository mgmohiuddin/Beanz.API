using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAccountOpeningDetailBusiness
    {
        Task<List<AccountOpeningDetailDTO>> GetAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<AccountOpeningDetailViewModel> GetInfoAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAccountOpeningDetailsAsync(BeanzCommonDTO lookup);
        Task<AccountOpeningDetailViewModel> PrintAccountOpeningDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAccountOpeningDetailsAsync(BeanzCommonDTO common);
    }
}
