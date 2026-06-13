using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface ILoanPolicyEligibleRepository
    {
        Task<List<LoanPolicyEligibleDTO>> GetLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLoanPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<LoanPolicyEligibleViewModel> GetInfoLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<LoanPolicyEligibleViewModel> PrintLoanPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLoanPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
