using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ILoanPolicyPaymentRepository
    {
        Task<List<LoanPolicyPaymentDTO>> GetLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLoanPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<LoanPolicyPaymentViewModel> GetInfoLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<LoanPolicyPaymentViewModel> PrintLoanPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLoanPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
