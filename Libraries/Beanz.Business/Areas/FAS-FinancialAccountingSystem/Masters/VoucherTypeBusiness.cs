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
    public class VoucherTypeBusiness : IVoucherTypeBusiness
    {
        private readonly IVoucherTypeRepository _repository;

        public VoucherTypeBusiness(IVoucherTypeRepository repository)
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
        public Task<List<VoucherTypeDTO>> GetVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<VoucherTypeDTO>());
            return _repository.GetVoucherTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            VoucherTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<VoucherTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.VoucherTypeCode))
                return Fail("ERR013", "VoucherType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.VoucherTypeName))
                return Fail("ERR014", "VoucherType Name is required.");

            return await _repository.SetVoucherTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostVoucherTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelVoucherTypesAsync(common);
        }

        public Task<VoucherTypeViewModel> GetInfoVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new VoucherTypeViewModel());
            return _repository.GetInfoVoucherTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpVoucherTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpVoucherTypesAsync(lookup);

        public Task<VoucherTypeViewModel> PrintVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new VoucherTypeViewModel());
            return _repository.PrintVoucherTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveVoucherTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveVoucherTypesAsync(common);
        }
    }
}
