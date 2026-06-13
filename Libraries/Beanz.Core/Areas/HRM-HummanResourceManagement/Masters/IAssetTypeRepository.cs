using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IAssetTypeRepository
    {
        Task<List<AssetTypeDTO>> GetAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAssetTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAssetTypesAsync(BeanzCommonDTO lookup);
        Task<AssetTypeViewModel> GetInfoAssetTypesAsync(BeanzCommonDTO common);
        Task<AssetTypeViewModel> PrintAssetTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAssetTypesAsync(BeanzCommonDTO common);
    }
}
