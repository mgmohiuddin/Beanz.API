using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IPaidTimeOffPolicyEligibleRepository
    {
        Task<List<PaidTimeOffPolicyEligibleDTO>> GetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<PaidTimeOffPolicyEligibleViewModel> GetInfoPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<PaidTimeOffPolicyEligibleViewModel> PrintPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
