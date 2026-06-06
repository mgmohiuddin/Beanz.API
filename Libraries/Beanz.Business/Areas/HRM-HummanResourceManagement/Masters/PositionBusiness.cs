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
    public class PositionBusiness : IPositionBusiness
    {
        private readonly IPositionRepository _repository;

        public PositionBusiness(IPositionRepository repository)
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
        public Task<List<PositionDTO>> GetPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<PositionDTO>());
            return _repository.GetPositionsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            PositionDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<PositionDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.PositionCode))
                return Fail("ERR013", "Position Code is required.");
            if (string.IsNullOrWhiteSpace(dto.PositionName))
                return Fail("ERR014", "Position Name is required.");

            return await _repository.SetPositionsAsync(common);
        }

        public Task<BeanzResponseDTO> PostPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostPositionsAsync(common);
        }

        public Task<BeanzResponseDTO> DelPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelPositionsAsync(common);
        }

        public Task<PositionViewModel> GetInfoPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new PositionViewModel());
            return _repository.GetInfoPositionsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpPositionsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpPositionsAsync(lookup);

        public Task<PositionViewModel> PrintPositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new PositionViewModel());
            return _repository.PrintPositionsAsync(common);
        }

        public Task<BeanzResponseDTO> ApprovePositionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApprovePositionsAsync(common);
        }
    }
}
