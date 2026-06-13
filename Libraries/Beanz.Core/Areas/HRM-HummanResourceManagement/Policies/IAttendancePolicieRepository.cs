using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IAttendancePolicieRepository
    {
        Task<List<AttendancePolicieDTO>> GetAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAttendancePoliciesAsync(BeanzCommonDTO lookup);
        Task<AttendancePolicieViewModel> GetInfoAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<AttendancePolicieViewModel> PrintAttendancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAttendancePoliciesAsync(BeanzCommonDTO common);
    }
}
