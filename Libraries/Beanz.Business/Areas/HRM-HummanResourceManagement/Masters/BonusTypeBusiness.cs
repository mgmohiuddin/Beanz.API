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
    public class BonusTypeBusiness : IBonusTypeBusiness
    {
        private readonly IBonusTypeRepository _repository;

        public BonusTypeBusiness(IBonusTypeRepository repository)
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
        public Task<List<BonusTypeDTO>> GetBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<BonusTypeDTO>());
            return _repository.GetBonusTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            BonusTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<BonusTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.BonusTypeCode))
                return Fail("ERR013", "BonusType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.BonusTypeName))
                return Fail("ERR014", "BonusType Name is required.");

            return await _repository.SetBonusTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostBonusTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelBonusTypesAsync(common);
        }

        public Task<BonusTypeViewModel> GetInfoBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new BonusTypeViewModel());
            return _repository.GetInfoBonusTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpBonusTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpBonusTypesAsync(lookup);

        public Task<BonusTypeViewModel> PrintBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new BonusTypeViewModel());
            return _repository.PrintBonusTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveBonusTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveBonusTypesAsync(common);
        }
    }
}
