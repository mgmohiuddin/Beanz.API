using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;

namespace Beanz.Business.Areas.HumanResourceManagement.Masters
{
    public class PaidTimeOffTypeBusiness : IPaidTimeOffTypeBusiness
    {
        private readonly IPaidTimeOffTypeRepository _repository;

        public PaidTimeOffTypeBusiness(IPaidTimeOffTypeRepository repository)
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
        public Task<List<PaidTimeOffTypeDTO>> GetPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<PaidTimeOffTypeDTO>());
            return _repository.GetPaidTimeOffTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            PaidTimeOffTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<PaidTimeOffTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.PaidTimeOffTypeCode))
                return Fail("ERR013", "PaidTimeOffType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.PaidTimeOffTypeName))
                return Fail("ERR014", "PaidTimeOffType Name is required.");

            return await _repository.SetPaidTimeOffTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostPaidTimeOffTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelPaidTimeOffTypesAsync(common);
        }

        public Task<PaidTimeOffTypeViewModel> GetInfoPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new PaidTimeOffTypeViewModel());
            return _repository.GetInfoPaidTimeOffTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpPaidTimeOffTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpPaidTimeOffTypesAsync(lookup);

        public Task<PaidTimeOffTypeViewModel> PrintPaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new PaidTimeOffTypeViewModel());
            return _repository.PrintPaidTimeOffTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApprovePaidTimeOffTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApprovePaidTimeOffTypesAsync(common);
        }
    }
}
