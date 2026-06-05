using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAttendanceTypeRepository
    {
        Task<List<AttendanceTypeDTO>> GetAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAttendanceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAttendanceTypesAsync(BeanzCommonDTO lookup);
        Task<AttendanceTypeViewModel> GetInfoAttendanceTypesAsync(BeanzCommonDTO common);
        Task<AttendanceTypeViewModel> PrintAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAttendanceTypesAsync(BeanzCommonDTO common);
    }
}
