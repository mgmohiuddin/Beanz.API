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
    public class AllowanceBusiness : IAllowanceBusiness
    {
        private readonly IAllowanceRepository _repository;

        public AllowanceBusiness(IAllowanceRepository repository)
        {
            _repository = repository;
        }

        // ---------- Validation Helpers ----------
        private static BeanzResponseDTO Fail(string code, string message)
            => new BeanzResponseDTO { ErrorCode = code, ErrorMessage = message };

        private static BeanzResponseDTO ValidateContext(BeanzRequestDTO common)
        {
            if (common == null)
                return Fail("ERR001", "Request payload is required.");
            if (common.CompanyID <= 0)
                return Fail("ERR002", "CompanyID is required.");
            if (common.UserID <= 0)
                return Fail("ERR003", "UserID is required.");
            return null;
        }

        private static BeanzResponseDTO ValidateKey(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;
            if (common.PrimaryKeyID <= 0)
                return Fail("ERR010", "PrimaryKeyID is required.");
            return null;
        }

        // ---------- Methods ----------
        public Task<BeanzResponseObjectDTO<List<AllowanceDTO>>> GetAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new BeanzResponseObjectDTO<List<AllowanceDTO>>());
            return _repository.GetAllowancesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AllowanceDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AllowanceDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AllowanceCode))
                return Fail("ERR013", "Allowance Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AllowanceName))
                return Fail("ERR014", "Allowance Name is required.");

            return await _repository.SetAllowancesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAllowancesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAllowancesAsync(common);
        }

        public Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AllowanceViewModel());
            return _repository.GetInfoAllowancesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAllowancesAsync(BeanzRequestDTO lookup)
            => _repository.LookUpAllowancesAsync(lookup);

        public Task<AllowanceViewModel> PrintAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AllowanceViewModel());
            return _repository.PrintAllowancesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAllowancesAsync(common);
        }
    }
}
