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
    public class FiscalYearBusiness : IFiscalYearBusiness
    {
        private readonly IFiscalYearRepository _repository;

        public FiscalYearBusiness(IFiscalYearRepository repository)
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
        public Task<List<FiscalYearDTO>> GetFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<FiscalYearDTO>());
            return _repository.GetFiscalYearsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            FiscalYearDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<FiscalYearDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.FiscalYearCode))
                return Fail("ERR013", "FiscalYear Code is required.");
            if (string.IsNullOrWhiteSpace(dto.FiscalYearName))
                return Fail("ERR014", "FiscalYear Name is required.");

            return await _repository.SetFiscalYearsAsync(common);
        }

        public Task<BeanzResponseDTO> PostFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostFiscalYearsAsync(common);
        }

        public Task<BeanzResponseDTO> DelFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelFiscalYearsAsync(common);
        }

        public Task<FiscalYearViewModel> GetInfoFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new FiscalYearViewModel());
            return _repository.GetInfoFiscalYearsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpFiscalYearsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpFiscalYearsAsync(lookup);

        public Task<FiscalYearViewModel> PrintFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new FiscalYearViewModel());
            return _repository.PrintFiscalYearsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveFiscalYearsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveFiscalYearsAsync(common);
        }
    }
}
