using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAdjustmentDetailRepository
    {
        Task<List<AdjustmentDetailDTO>> GetAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdjustmentDetailsAsync(BeanzCommonDTO lookup);
        Task<AdjustmentDetailViewModel> GetInfoAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<AdjustmentDetailViewModel> PrintAdjustmentDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdjustmentDetailsAsync(BeanzCommonDTO common);
    }
}
