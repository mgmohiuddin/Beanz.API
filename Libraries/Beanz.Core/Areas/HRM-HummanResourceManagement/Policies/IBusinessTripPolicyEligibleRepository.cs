using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBusinessTripPolicyEligibleRepository
    {
        Task<List<BusinessTripPolicyEligibleDTO>> GetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripPolicyEligibleViewModel> GetInfoBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BusinessTripPolicyEligibleViewModel> PrintBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
