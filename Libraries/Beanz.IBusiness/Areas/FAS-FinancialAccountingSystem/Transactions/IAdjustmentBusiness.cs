using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions
{
    public interface IAdjustmentBusiness
    {
        Task<List<AdjustmentDTO>> GetAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdjustmentsAsync(BeanzCommonDTO common);
        Task<AdjustmentViewModel> GetInfoAdjustmentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdjustmentsAsync(BeanzCommonDTO lookup);
        Task<AdjustmentViewModel> PrintAdjustmentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdjustmentsAsync(BeanzCommonDTO common);
    }
}
