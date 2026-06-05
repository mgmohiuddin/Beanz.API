using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAdvanceSalaryPolicieRepository
    {
        Task<List<AdvanceSalaryPolicieDTO>> GetAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPoliciesAsync(BeanzCommonDTO lookup);
        Task<AdvanceSalaryPolicieViewModel> GetInfoAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<AdvanceSalaryPolicieViewModel> PrintAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAdvanceSalaryPoliciesAsync(BeanzCommonDTO common);
    }
}
