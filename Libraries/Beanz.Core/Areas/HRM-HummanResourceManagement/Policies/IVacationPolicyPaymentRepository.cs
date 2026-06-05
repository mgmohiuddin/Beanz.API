using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IVacationPolicyPaymentRepository
    {
        Task<List<VacationPolicyPaymentDTO>> GetVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVacationPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<VacationPolicyPaymentViewModel> GetInfoVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<VacationPolicyPaymentViewModel> PrintVacationPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVacationPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
