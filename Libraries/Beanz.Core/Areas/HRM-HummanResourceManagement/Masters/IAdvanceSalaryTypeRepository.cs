using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IAdvanceSalaryTypeRepository
    {
        Task<BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>> GetAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseObjectDTO<int?>> SetAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzRequestDTO lookup);
        Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzRequestDTO common);
    }
}
