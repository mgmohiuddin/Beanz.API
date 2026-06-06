using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAdvanceSalaryPolicyEligibleRepository
    {
        Task<List<AdvanceSalaryPolicyEligibleDTO>> GetAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<AdvanceSalaryPolicyEligibleViewModel> GetInfoAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<AdvanceSalaryPolicyEligibleViewModel> PrintAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
