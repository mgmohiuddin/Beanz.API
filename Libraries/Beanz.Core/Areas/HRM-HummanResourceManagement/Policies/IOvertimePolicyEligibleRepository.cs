using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IOvertimePolicyEligibleRepository
    {
        Task<List<OvertimePolicyEligibleDTO>> GetOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOvertimePolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<OvertimePolicyEligibleViewModel> GetInfoOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<OvertimePolicyEligibleViewModel> PrintOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOvertimePolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
