using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IBonusTypeBusiness
    {
        Task<List<BonusTypeDTO>> GetBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBonusTypesAsync(BeanzCommonDTO common);
        Task<BonusTypeViewModel> GetInfoBonusTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBonusTypesAsync(BeanzCommonDTO lookup);
        Task<BonusTypeViewModel> PrintBonusTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBonusTypesAsync(BeanzCommonDTO common);
    }
}
