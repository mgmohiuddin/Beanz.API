using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IInsurancePolicyEligibleRepository
    {
        Task<List<InsurancePolicyEligibleDTO>> GetInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpInsurancePolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<InsurancePolicyEligibleViewModel> GetInfoInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<InsurancePolicyEligibleViewModel> PrintInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveInsurancePolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
