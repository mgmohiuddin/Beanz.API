using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IOvertimeTypeRepository
    {
        Task<List<OvertimeTypeDTO>> GetOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOvertimeTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOvertimeTypesAsync(BeanzCommonDTO lookup);
        Task<OvertimeTypeViewModel> GetInfoOvertimeTypesAsync(BeanzCommonDTO common);
        Task<OvertimeTypeViewModel> PrintOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOvertimeTypesAsync(BeanzCommonDTO common);
    }
}
