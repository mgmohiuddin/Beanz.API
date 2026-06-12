using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface ICostCenterRepository
    {
        Task<List<CostCenterDTO>> GetCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelCostCentersAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpCostCentersAsync(BeanzCommonDTO lookup);
        Task<CostCenterViewModel> GetInfoCostCentersAsync(BeanzCommonDTO common);
        Task<CostCenterViewModel> PrintCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveCostCentersAsync(BeanzCommonDTO common);
    }
}
