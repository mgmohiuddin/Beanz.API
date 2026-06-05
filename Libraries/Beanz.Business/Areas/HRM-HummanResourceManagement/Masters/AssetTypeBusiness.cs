using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AssetTypeBusiness
    {
        private readonly IAssetTypeRepository _repository;

        public AssetTypeBusiness(IAssetTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AssetTypeDTO>> GetAssetTypesAsync(BeanzCommonDTO common)
            => _repository.GetAssetTypesAsync(common);

        public Task<BeanzResponseDTO> SetAssetTypesAsync(BeanzCommonDTO common)
            => _repository.SetAssetTypesAsync(common);

        public Task<BeanzResponseDTO> PostAssetTypesAsync(BeanzCommonDTO common)
            => _repository.PostAssetTypesAsync(common);

        public Task<BeanzResponseDTO> DelAssetTypesAsync(BeanzCommonDTO common)
            => _repository.DelAssetTypesAsync(common);

        public Task<AssetTypeViewModel> GetInfoAssetTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAssetTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveAssetTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveAssetTypesAsync(common);
    }
}
