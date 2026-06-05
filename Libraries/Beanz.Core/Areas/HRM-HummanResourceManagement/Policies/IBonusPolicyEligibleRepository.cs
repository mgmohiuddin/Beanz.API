using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBonusPolicyEligibleRepository
    {
        Task<List<BonusPolicyEligibleDTO>> GetBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBonusPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<BonusPolicyEligibleViewModel> GetInfoBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BonusPolicyEligibleViewModel> PrintBonusPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBonusPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
