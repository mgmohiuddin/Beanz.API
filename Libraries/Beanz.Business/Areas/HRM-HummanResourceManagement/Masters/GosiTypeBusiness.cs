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
    public class GosiTypeBusiness : IGosiTypeBusiness
    {
        private readonly IGosiTypeRepository _repository;

        public GosiTypeBusiness(IGosiTypeRepository repository)
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
        public Task<List<GosiTypeDTO>> GetGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<GosiTypeDTO>());
            return _repository.GetGosiTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            GosiTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<GosiTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.GosiTypeCode))
                return Fail("ERR013", "GosiType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.GosiTypeName))
                return Fail("ERR014", "GosiType Name is required.");

            return await _repository.SetGosiTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostGosiTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelGosiTypesAsync(common);
        }

        public Task<GosiTypeViewModel> GetInfoGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new GosiTypeViewModel());
            return _repository.GetInfoGosiTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpGosiTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpGosiTypesAsync(lookup);

        public Task<GosiTypeViewModel> PrintGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new GosiTypeViewModel());
            return _repository.PrintGosiTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveGosiTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveGosiTypesAsync(common);
        }
    }
}
