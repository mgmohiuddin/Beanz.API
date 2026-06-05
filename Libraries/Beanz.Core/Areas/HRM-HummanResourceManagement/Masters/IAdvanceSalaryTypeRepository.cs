using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAdvanceSalaryTypeRepository
    {
        Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzCommonDTO lookup);
        Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzCommonDTO common);
    }
}
