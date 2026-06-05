using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IBonusTypeRepository
    {
        Task<List<BonusTypeDTO>> GetBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBonusTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBonusTypesAsync(BeanzCommonDTO lookup);
        Task<BonusTypeViewModel> GetInfoBonusTypesAsync(BeanzCommonDTO common);
        Task<BonusTypeViewModel> PrintBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBonusTypesAsync(BeanzCommonDTO common);
    }
}
