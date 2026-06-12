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
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IAccountRepository _repository;

        public AccountBusiness(IAccountRepository repository)
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
        public Task<List<AccountDTO>> GetAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AccountDTO>());
            return _repository.GetAccountsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AccountDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AccountDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AccountCode))
                return Fail("ERR013", "Account Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AccountName))
                return Fail("ERR014", "Account Name is required.");

            return await _repository.SetAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAccountsAsync(common);
        }

        public Task<AccountViewModel> GetInfoAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AccountViewModel());
            return _repository.GetInfoAccountsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAccountsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAccountsAsync(lookup);

        public Task<AccountViewModel> PrintAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AccountViewModel());
            return _repository.PrintAccountsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAccountsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAccountsAsync(common);
        }
    }
}
