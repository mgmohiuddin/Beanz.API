using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ILeaveTypeRepository
    {
        Task<List<LeaveTypeDTO>> GetLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeaveTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeaveTypesAsync(BeanzCommonDTO lookup);
        Task<LeaveTypeViewModel> GetInfoLeaveTypesAsync(BeanzCommonDTO common);
        Task<LeaveTypeViewModel> PrintLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeaveTypesAsync(BeanzCommonDTO common);
    }
}
