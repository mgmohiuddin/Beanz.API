using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAdjustmentRepository
    {
        Task<List<AdjustmentDTO>> GetAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdjustmentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdjustmentsAsync(BeanzCommonDTO lookup);
        Task<AdjustmentViewModel> GetInfoAdjustmentsAsync(BeanzCommonDTO common);
        Task<AdjustmentViewModel> PrintAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdjustmentsAsync(BeanzCommonDTO common);
    }
}
