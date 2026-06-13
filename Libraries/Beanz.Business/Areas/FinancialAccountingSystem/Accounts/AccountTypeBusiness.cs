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
    public class AccountTypeBusiness : IAccountTypeBusiness
    {
        private readonly IAccountTypeRepository _repository;

        public AccountTypeBusiness(IAccountTypeRepository repository)
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
        public Task<List<AccountTypeDTO>> GetAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AccountTypeDTO>());
            return _repository.GetAccountTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AccountTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AccountTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AccountTypeCode))
                return Fail("ERR013", "AccountType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AccountTypeName))
                return Fail("ERR014", "AccountType Name is required.");

            return await _repository.SetAccountTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAccountTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAccountTypesAsync(common);
        }

        public Task<AccountTypeViewModel> GetInfoAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AccountTypeViewModel());
            return _repository.GetInfoAccountTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAccountTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAccountTypesAsync(lookup);

        public Task<AccountTypeViewModel> PrintAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AccountTypeViewModel());
            return _repository.PrintAccountTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAccountTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAccountTypesAsync(common);
        }
    }
}
