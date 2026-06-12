using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Accounts
{
    public class ChartOfAccountBusiness : IChartOfAccountBusiness
    {
        private readonly IChartOfAccountRepository _repository;

        public ChartOfAccountBusiness(IChartOfAccountRepository repository)
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
        public Task<List<ChartOfAccountDTO>> GetChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<ChartOfAccountDTO>());
            return _repository.GetChartOfAccountsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            ChartOfAccountDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<ChartOfAccountDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.ChartOfAccountCode))
                return Fail("ERR013", "ChartOfAccount Code is required.");
            if (string.IsNullOrWhiteSpace(dto.ChartOfAccountName))
                return Fail("ERR014", "ChartOfAccount Name is required.");

            return await _repository.SetChartOfAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> PostChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostChartOfAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> DelChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelChartOfAccountsAsync(common);
        }

        public Task<ChartOfAccountViewModel> GetInfoChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new ChartOfAccountViewModel());
            return _repository.GetInfoChartOfAccountsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpChartOfAccountsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpChartOfAccountsAsync(lookup);

        public Task<ChartOfAccountViewModel> PrintChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new ChartOfAccountViewModel());
            return _repository.PrintChartOfAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveChartOfAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveChartOfAccountsAsync(common);
        }
    }
}
