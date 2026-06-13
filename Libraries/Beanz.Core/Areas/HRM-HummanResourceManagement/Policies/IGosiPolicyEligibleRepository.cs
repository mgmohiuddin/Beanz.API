using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IGosiPolicyEligibleRepository
    {
        Task<List<GosiPolicyEligibleDTO>> GetGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<GosiPolicyEligibleViewModel> GetInfoGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<GosiPolicyEligibleViewModel> PrintGosiPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
