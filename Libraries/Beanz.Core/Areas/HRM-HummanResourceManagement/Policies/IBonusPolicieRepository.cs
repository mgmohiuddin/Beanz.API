using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBonusPolicieRepository
    {
        Task<List<BonusPolicieDTO>> GetBonusPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBonusPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBonusPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBonusPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBonusPoliciesAsync(BeanzCommonDTO lookup);
        Task<BonusPolicieViewModel> GetInfoBonusPoliciesAsync(BeanzCommonDTO common);
        Task<BonusPolicieViewModel> PrintBonusPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBonusPoliciesAsync(BeanzCommonDTO common);
    }
}
