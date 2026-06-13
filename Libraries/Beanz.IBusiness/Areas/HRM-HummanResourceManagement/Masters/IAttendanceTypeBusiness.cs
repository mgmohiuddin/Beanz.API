using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IAttendanceTypeBusiness
    {
        Task<List<AttendanceTypeDTO>> GetAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAttendanceTypesAsync(BeanzCommonDTO common);
        Task<AttendanceTypeViewModel> GetInfoAttendanceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAttendanceTypesAsync(BeanzCommonDTO lookup);
        Task<AttendanceTypeViewModel> PrintAttendanceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAttendanceTypesAsync(BeanzCommonDTO common);
    }
}
