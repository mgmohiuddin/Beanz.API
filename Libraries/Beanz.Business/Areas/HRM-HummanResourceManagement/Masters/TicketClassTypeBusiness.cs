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
    public class TicketClassTypeBusiness : ITicketClassTypeBusiness
    {
        private readonly ITicketClassTypeRepository _repository;

        public TicketClassTypeBusiness(ITicketClassTypeRepository repository)
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
        public Task<List<TicketClassTypeDTO>> GetTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<TicketClassTypeDTO>());
            return _repository.GetTicketClassTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            TicketClassTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<TicketClassTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.TicketClassTypeCode))
                return Fail("ERR013", "TicketClassType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.TicketClassTypeName))
                return Fail("ERR014", "TicketClassType Name is required.");

            return await _repository.SetTicketClassTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostTicketClassTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelTicketClassTypesAsync(common);
        }

        public Task<TicketClassTypeViewModel> GetInfoTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new TicketClassTypeViewModel());
            return _repository.GetInfoTicketClassTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpTicketClassTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpTicketClassTypesAsync(lookup);

        public Task<TicketClassTypeViewModel> PrintTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new TicketClassTypeViewModel());
            return _repository.PrintTicketClassTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveTicketClassTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveTicketClassTypesAsync(common);
        }
    }
}
