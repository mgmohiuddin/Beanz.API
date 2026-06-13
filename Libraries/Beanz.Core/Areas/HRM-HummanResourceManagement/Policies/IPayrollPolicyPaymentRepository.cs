using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IPayrollPolicyPaymentRepository
    {
        Task<List<PayrollPolicyPaymentDTO>> GetPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<PayrollPolicyPaymentViewModel> GetInfoPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<PayrollPolicyPaymentViewModel> PrintPayrollPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
