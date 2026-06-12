using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Masters
{
    public class TaxTypeBusiness : ITaxTypeBusiness
    {
        private readonly ITaxTypeRepository _repository;

        public TaxTypeBusiness(ITaxTypeRepository repository)
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
        public Task<List<TaxTypeDTO>> GetTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<TaxTypeDTO>());
            return _repository.GetTaxTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            TaxTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<TaxTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.TaxTypeCode))
                return Fail("ERR013", "TaxType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.TaxTypeName))
                return Fail("ERR014", "TaxType Name is required.");

            return await _repository.SetTaxTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostTaxTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelTaxTypesAsync(common);
        }

        public Task<TaxTypeViewModel> GetInfoTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new TaxTypeViewModel());
            return _repository.GetInfoTaxTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpTaxTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpTaxTypesAsync(lookup);

        public Task<TaxTypeViewModel> PrintTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new TaxTypeViewModel());
            return _repository.PrintTaxTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveTaxTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveTaxTypesAsync(common);
        }
    }
}
