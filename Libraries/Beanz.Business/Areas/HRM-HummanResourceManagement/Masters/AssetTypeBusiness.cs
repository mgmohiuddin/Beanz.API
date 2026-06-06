using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AssetTypeBusiness : IAssetTypeBusiness
    {
        private readonly IAssetTypeRepository _repository;

        public AssetTypeBusiness(IAssetTypeRepository repository)
        {
            _repository = repository;
        }

        // ---------- Validation Helpers ----------
        private static BeanzResponseDTO Fail(string code, string message)
            => new BeanzResponseDTO { ErrorCode = code, ErrorMessage = message };

        private static BeanzResponseDTO ValidateContext(BeanzCommonDTO common)
        {
            if (common == null)
                return Fail("ERR001", "Request payload is required.");
            if (common.CompanyID <= 0)
                return Fail("ERR002", "CompanyID is required.");
            if (common.UserID <= 0)
                return Fail("ERR003", "UserID is required.");
            return null;
        }

        private static BeanzResponseDTO ValidateKey(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;
            if (common.PrimaryKeyID <= 0)
                return Fail("ERR010", "PrimaryKeyID is required.");
            return null;
        }

        // ---------- Methods ----------
        public Task<List<AssetTypeDTO>> GetAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AssetTypeDTO>());
            return _repository.GetAssetTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AssetTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AssetTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AssetTypeCode))
                return Fail("ERR013", "AssetType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AssetTypeName))
                return Fail("ERR014", "AssetType Name is required.");

            return await _repository.SetAssetTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAssetTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAssetTypesAsync(common);
        }

        public Task<AssetTypeViewModel> GetInfoAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AssetTypeViewModel());
            return _repository.GetInfoAssetTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAssetTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAssetTypesAsync(lookup);

        public Task<AssetTypeViewModel> PrintAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AssetTypeViewModel());
            return _repository.PrintAssetTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAssetTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAssetTypesAsync(common);
        }
    }
}
