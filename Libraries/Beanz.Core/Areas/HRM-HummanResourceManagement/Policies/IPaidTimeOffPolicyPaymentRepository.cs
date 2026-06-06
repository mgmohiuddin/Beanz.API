using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IPaidTimeOffPolicyPaymentRepository
    {
        Task<List<PaidTimeOffPolicyPaymentDTO>> GetPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<PaidTimeOffPolicyPaymentViewModel> GetInfoPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<PaidTimeOffPolicyPaymentViewModel> PrintPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
