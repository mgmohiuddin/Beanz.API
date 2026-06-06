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
    public class PayrollTypeBusiness : IPayrollTypeBusiness
    {
        private readonly IPayrollTypeRepository _repository;

        public PayrollTypeBusiness(IPayrollTypeRepository repository)
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
        public Task<List<PayrollTypeDTO>> GetPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<PayrollTypeDTO>());
            return _repository.GetPayrollTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            PayrollTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<PayrollTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.PayrollTypeCode))
                return Fail("ERR013", "PayrollType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.PayrollTypeName))
                return Fail("ERR014", "PayrollType Name is required.");

            return await _repository.SetPayrollTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostPayrollTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelPayrollTypesAsync(common);
        }

        public Task<PayrollTypeViewModel> GetInfoPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new PayrollTypeViewModel());
            return _repository.GetInfoPayrollTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpPayrollTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpPayrollTypesAsync(lookup);

        public Task<PayrollTypeViewModel> PrintPayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new PayrollTypeViewModel());
            return _repository.PrintPayrollTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApprovePayrollTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApprovePayrollTypesAsync(common);
        }
    }
}
