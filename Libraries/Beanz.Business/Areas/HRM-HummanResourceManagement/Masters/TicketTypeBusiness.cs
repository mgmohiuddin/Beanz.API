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
    public class TicketTypeBusiness : ITicketTypeBusiness
    {
        private readonly ITicketTypeRepository _repository;

        public TicketTypeBusiness(ITicketTypeRepository repository)
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
        public Task<List<TicketTypeDTO>> GetTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<TicketTypeDTO>());
            return _repository.GetTicketTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            TicketTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<TicketTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.TicketTypeCode))
                return Fail("ERR013", "TicketType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.TicketTypeName))
                return Fail("ERR014", "TicketType Name is required.");

            return await _repository.SetTicketTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostTicketTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelTicketTypesAsync(common);
        }

        public Task<TicketTypeViewModel> GetInfoTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new TicketTypeViewModel());
            return _repository.GetInfoTicketTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpTicketTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpTicketTypesAsync(lookup);

        public Task<TicketTypeViewModel> PrintTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new TicketTypeViewModel());
            return _repository.PrintTicketTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveTicketTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveTicketTypesAsync(common);
        }
    }
}
