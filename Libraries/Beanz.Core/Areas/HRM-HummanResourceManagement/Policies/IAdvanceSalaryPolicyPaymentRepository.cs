using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAdvanceSalaryPolicyPaymentRepository
    {
        Task<List<AdvanceSalaryPolicyPaymentDTO>> GetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<AdvanceSalaryPolicyPaymentViewModel> GetInfoAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<AdvanceSalaryPolicyPaymentViewModel> PrintAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
