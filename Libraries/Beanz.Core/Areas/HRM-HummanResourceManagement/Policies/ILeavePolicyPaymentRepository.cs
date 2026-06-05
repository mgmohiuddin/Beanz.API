using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ILeavePolicyPaymentRepository
    {
        Task<List<LeavePolicyPaymentDTO>> GetLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeavePolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<LeavePolicyPaymentViewModel> GetInfoLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<LeavePolicyPaymentViewModel> PrintLeavePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeavePolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
