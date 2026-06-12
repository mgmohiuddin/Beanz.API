using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAdjustmentDetailBusiness
    {
        Task<List<AdjustmentDetailDTO>> GetAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<AdjustmentDetailViewModel> GetInfoAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdjustmentDetailsAsync(BeanzCommonDTO lookup);
        Task<AdjustmentDetailViewModel> PrintAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdjustmentDetailsAsync(BeanzCommonDTO common);
    }
}
