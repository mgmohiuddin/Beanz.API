using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAttendancePolicyPaymentRepository
    {
        Task<List<AttendancePolicyPaymentDTO>> GetAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAttendancePolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<AttendancePolicyPaymentViewModel> GetInfoAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<AttendancePolicyPaymentViewModel> PrintAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAttendancePolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
