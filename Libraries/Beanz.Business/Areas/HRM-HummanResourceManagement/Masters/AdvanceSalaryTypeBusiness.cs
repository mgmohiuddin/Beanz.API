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
    public class AdvanceSalaryTypeBusiness : IAdvanceSalaryTypeBusiness
    {
        private readonly IAdvanceSalaryTypeRepository _repository;

        public AdvanceSalaryTypeBusiness(IAdvanceSalaryTypeRepository repository)
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
        public Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AdvanceSalaryTypeDTO>());
            return _repository.GetAdvanceSalaryTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AdvanceSalaryTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AdvanceSalaryTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeCode))
                return Fail("ERR013", "AdvanceSalaryType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeName))
                return Fail("ERR014", "AdvanceSalaryType Name is required.");

            return await _repository.SetAdvanceSalaryTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAdvanceSalaryTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAdvanceSalaryTypesAsync(common);
        }

        public Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AdvanceSalaryTypeViewModel());
            return _repository.GetInfoAdvanceSalaryTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAdvanceSalaryTypesAsync(lookup);

        public Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AdvanceSalaryTypeViewModel());
            return _repository.PrintAdvanceSalaryTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAdvanceSalaryTypesAsync(common);
        }
    }
}
