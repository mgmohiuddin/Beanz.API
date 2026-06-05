using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceTypeRepository
    {
        Task<List<AllowanceTypeDTO>> GetAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowanceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowanceTypesAsync(BeanzCommonDTO lookup);
        Task<AllowanceTypeViewModel> GetInfoAllowanceTypesAsync(BeanzCommonDTO common);
        Task<AllowanceTypeViewModel> PrintAllowanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowanceTypesAsync(BeanzCommonDTO common);
    }
}
