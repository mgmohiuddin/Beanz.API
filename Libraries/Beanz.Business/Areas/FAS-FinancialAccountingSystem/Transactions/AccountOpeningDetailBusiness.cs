using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Transactions
{
    public class AccountOpeningDetailBusiness : IAccountOpeningDetailBusiness
    {
        private readonly IAccountOpeningDetailRepository _repository;

        public AccountOpeningDetailBusiness(IAccountOpeningDetailRepository repository)
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
        public Task<List<AccountOpeningDetailDTO>> GetAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AccountOpeningDetailDTO>());
            return _repository.GetAccountOpeningDetailsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AccountOpeningDetailDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AccountOpeningDetailDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AccountOpeningDetailCode))
                return Fail("ERR013", "AccountOpeningDetail Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AccountOpeningDetailName))
                return Fail("ERR014", "AccountOpeningDetail Name is required.");

            return await _repository.SetAccountOpeningDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAccountOpeningDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAccountOpeningDetailsAsync(common);
        }

        public Task<AccountOpeningDetailViewModel> GetInfoAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AccountOpeningDetailViewModel());
            return _repository.GetInfoAccountOpeningDetailsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAccountOpeningDetailsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAccountOpeningDetailsAsync(lookup);

        public Task<AccountOpeningDetailViewModel> PrintAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AccountOpeningDetailViewModel());
            return _repository.PrintAccountOpeningDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAccountOpeningDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAccountOpeningDetailsAsync(common);
        }
    }
}
