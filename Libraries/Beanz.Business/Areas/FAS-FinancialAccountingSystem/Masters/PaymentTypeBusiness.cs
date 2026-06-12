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
    public class PaymentTypeBusiness : IPaymentTypeBusiness
    {
        private readonly IPaymentTypeRepository _repository;

        public PaymentTypeBusiness(IPaymentTypeRepository repository)
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
        public Task<List<PaymentTypeDTO>> GetPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<PaymentTypeDTO>());
            return _repository.GetPaymentTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            PaymentTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<PaymentTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.PaymentTypeCode))
                return Fail("ERR013", "PaymentType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.PaymentTypeName))
                return Fail("ERR014", "PaymentType Name is required.");

            return await _repository.SetPaymentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostPaymentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelPaymentTypesAsync(common);
        }

        public Task<PaymentTypeViewModel> GetInfoPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new PaymentTypeViewModel());
            return _repository.GetInfoPaymentTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpPaymentTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpPaymentTypesAsync(lookup);

        public Task<PaymentTypeViewModel> PrintPaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new PaymentTypeViewModel());
            return _repository.PrintPaymentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApprovePaymentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApprovePaymentTypesAsync(common);
        }
    }
}
