using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface ILeaveTypeBusiness
    {
        Task<List<LeaveTypeDTO>> GetLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeaveTypesAsync(BeanzCommonDTO common);
        Task<LeaveTypeViewModel> GetInfoLeaveTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeaveTypesAsync(BeanzCommonDTO lookup);
        Task<LeaveTypeViewModel> PrintLeaveTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeaveTypesAsync(BeanzCommonDTO common);
    }
}
