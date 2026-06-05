using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ILeavePolicyEligibleRepository
    {
        Task<List<LeavePolicyEligibleDTO>> GetLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeavePolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<LeavePolicyEligibleViewModel> GetInfoLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<LeavePolicyEligibleViewModel> PrintLeavePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeavePolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
