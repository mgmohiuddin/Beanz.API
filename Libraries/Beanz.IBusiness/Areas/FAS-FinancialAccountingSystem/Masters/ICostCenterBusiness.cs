using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface ICostCenterBusiness
    {
        Task<List<CostCenterDTO>> GetCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelCostCentersAsync(BeanzCommonDTO common);
        Task<CostCenterViewModel> GetInfoCostCentersAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpCostCentersAsync(BeanzCommonDTO lookup);
        Task<CostCenterViewModel> PrintCostCentersAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveCostCentersAsync(BeanzCommonDTO common);
    }
}
