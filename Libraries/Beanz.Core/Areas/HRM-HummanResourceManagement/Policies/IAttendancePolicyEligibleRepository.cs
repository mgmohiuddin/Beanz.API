using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IAttendancePolicyEligibleRepository
    {
        Task<List<AttendancePolicyEligibleDTO>> GetAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAttendancePolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<AttendancePolicyEligibleViewModel> GetInfoAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<AttendancePolicyEligibleViewModel> PrintAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAttendancePolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
