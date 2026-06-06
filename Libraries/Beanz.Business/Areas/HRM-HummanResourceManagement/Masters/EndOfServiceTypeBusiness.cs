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
    public class EndOfServiceTypeBusiness : IEndOfServiceTypeBusiness
    {
        private readonly IEndOfServiceTypeRepository _repository;

        public EndOfServiceTypeBusiness(IEndOfServiceTypeRepository repository)
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
        public Task<List<EndOfServiceTypeDTO>> GetEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<EndOfServiceTypeDTO>());
            return _repository.GetEndOfServiceTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            EndOfServiceTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<EndOfServiceTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.EndOfServiceTypeCode))
                return Fail("ERR013", "EndOfServiceType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.EndOfServiceTypeName))
                return Fail("ERR014", "EndOfServiceType Name is required.");

            return await _repository.SetEndOfServiceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostEndOfServiceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelEndOfServiceTypesAsync(common);
        }

        public Task<EndOfServiceTypeViewModel> GetInfoEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new EndOfServiceTypeViewModel());
            return _repository.GetInfoEndOfServiceTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpEndOfServiceTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpEndOfServiceTypesAsync(lookup);

        public Task<EndOfServiceTypeViewModel> PrintEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new EndOfServiceTypeViewModel());
            return _repository.PrintEndOfServiceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveEndOfServiceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveEndOfServiceTypesAsync(common);
        }
    }
}
