using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ILoanPolicieRepository
    {
        Task<List<LoanPolicieDTO>> GetLoanPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLoanPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLoanPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLoanPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLoanPoliciesAsync(BeanzCommonDTO lookup);
        Task<LoanPolicieViewModel> GetInfoLoanPoliciesAsync(BeanzCommonDTO common);
        Task<LoanPolicieViewModel> PrintLoanPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLoanPoliciesAsync(BeanzCommonDTO common);
    }
}
