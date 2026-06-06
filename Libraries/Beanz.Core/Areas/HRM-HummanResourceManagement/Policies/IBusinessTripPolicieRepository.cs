using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBusinessTripPolicieRepository
    {
        Task<List<BusinessTripPolicieDTO>> GetBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripPoliciesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripPolicieViewModel> GetInfoBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<BusinessTripPolicieViewModel> PrintBusinessTripPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripPoliciesAsync(BeanzCommonDTO common);
    }
}
