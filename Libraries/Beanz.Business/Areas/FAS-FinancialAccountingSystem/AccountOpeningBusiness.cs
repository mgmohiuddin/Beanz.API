using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Module;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Module;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Module;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Module
{
    public class AccountOpeningBusiness : IAccountOpeningBusiness
    {
        private readonly IAccountOpeningRepository _repository;

        public AccountOpeningBusiness(IAccountOpeningRepository repository)
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
        public Task<List<AccountOpeningDTO>> GetAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AccountOpeningDTO>());
            return _repository.GetAccountOpeningsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AccountOpeningDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AccountOpeningDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AccountOpeningCode))
                return Fail("ERR013", "AccountOpening Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AccountOpeningName))
                return Fail("ERR014", "AccountOpening Name is required.");

            return await _repository.SetAccountOpeningsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAccountOpeningsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAccountOpeningsAsync(common);
        }

        public Task<AccountOpeningViewModel> GetInfoAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AccountOpeningViewModel());
            return _repository.GetInfoAccountOpeningsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAccountOpeningsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAccountOpeningsAsync(lookup);

        public Task<AccountOpeningViewModel> PrintAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AccountOpeningViewModel());
            return _repository.PrintAccountOpeningsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAccountOpeningsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAccountOpeningsAsync(common);
        }
    }
}
