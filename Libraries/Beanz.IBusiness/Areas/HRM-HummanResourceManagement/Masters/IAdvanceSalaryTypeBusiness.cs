using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes; 

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAdvanceSalaryTypeBusiness
    {
        //Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>> GetAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseObjectDTO<int?>> SetAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzRequestDTO lookup);
        Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzRequestDTO common);
    }
}
