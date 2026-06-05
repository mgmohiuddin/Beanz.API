using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IOvertimePolicyPaymentRepository
    {
        Task<List<OvertimePolicyPaymentDTO>> GetOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOvertimePolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<OvertimePolicyPaymentViewModel> GetInfoOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<OvertimePolicyPaymentViewModel> PrintOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOvertimePolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
