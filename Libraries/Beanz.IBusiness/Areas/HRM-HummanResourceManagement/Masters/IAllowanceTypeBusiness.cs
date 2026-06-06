using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceTypeBusiness
    {
        Task<List<AllowanceTypeDTO>> GetAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowanceTypesAsync(BeanzCommonDTO common);
        Task<AllowanceTypeViewModel> GetInfoAllowanceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowanceTypesAsync(BeanzCommonDTO lookup);
        Task<AllowanceTypeViewModel> PrintAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowanceTypesAsync(BeanzCommonDTO common);
    }
}
