using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAssetTypeBusiness
    {
        Task<List<AssetTypeDTO>> GetAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAssetTypesAsync(BeanzCommonDTO common);
        Task<AssetTypeViewModel> GetInfoAssetTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAssetTypesAsync(BeanzCommonDTO lookup);
        Task<AssetTypeViewModel> PrintAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAssetTypesAsync(BeanzCommonDTO common);
    }
}
