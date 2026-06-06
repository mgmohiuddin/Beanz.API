using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAdvanceSalaryTypeBusiness
    {
        Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzCommonDTO lookup);
        Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzCommonDTO common);
    }
}
