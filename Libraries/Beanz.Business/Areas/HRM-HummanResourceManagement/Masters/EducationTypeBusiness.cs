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
    public class EducationTypeBusiness : IEducationTypeBusiness
    {
        private readonly IEducationTypeRepository _repository;

        public EducationTypeBusiness(IEducationTypeRepository repository)
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
        public Task<List<EducationTypeDTO>> GetEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<EducationTypeDTO>());
            return _repository.GetEducationTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            EducationTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<EducationTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.EducationTypeCode))
                return Fail("ERR013", "EducationType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.EducationTypeName))
                return Fail("ERR014", "EducationType Name is required.");

            return await _repository.SetEducationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostEducationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelEducationTypesAsync(common);
        }

        public Task<EducationTypeViewModel> GetInfoEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new EducationTypeViewModel());
            return _repository.GetInfoEducationTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpEducationTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpEducationTypesAsync(lookup);

        public Task<EducationTypeViewModel> PrintEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new EducationTypeViewModel());
            return _repository.PrintEducationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveEducationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveEducationTypesAsync(common);
        }
    }
}
