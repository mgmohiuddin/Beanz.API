using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;

namespace Beanz.Business.Areas.HumanResourceManagement.Masters
{
    public class AllowanceTypeBusiness : IAllowanceTypeBusiness
    {
        private readonly IAllowanceTypeRepository _repository;

        public AllowanceTypeBusiness(IAllowanceTypeRepository repository)
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
        public Task<List<AllowanceTypeDTO>> GetAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AllowanceTypeDTO>());
            return _repository.GetAllowanceTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AllowanceTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AllowanceTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AllowanceTypeCode))
                return Fail("ERR013", "AllowanceType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AllowanceTypeName))
                return Fail("ERR014", "AllowanceType Name is required.");

            return await _repository.SetAllowanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAllowanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAllowanceTypesAsync(common);
        }

        public Task<AllowanceTypeViewModel> GetInfoAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AllowanceTypeViewModel());
            return _repository.GetInfoAllowanceTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAllowanceTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAllowanceTypesAsync(lookup);

        public Task<AllowanceTypeViewModel> PrintAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AllowanceTypeViewModel());
            return _repository.PrintAllowanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAllowanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAllowanceTypesAsync(common);
        }
    }
}
