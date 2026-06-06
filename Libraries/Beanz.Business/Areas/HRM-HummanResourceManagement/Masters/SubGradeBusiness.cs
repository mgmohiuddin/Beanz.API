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
    public class SubGradeBusiness : ISubGradeBusiness
    {
        private readonly ISubGradeRepository _repository;

        public SubGradeBusiness(ISubGradeRepository repository)
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
        public Task<List<SubGradeDTO>> GetSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<SubGradeDTO>());
            return _repository.GetSubGradesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            SubGradeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<SubGradeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.SubGradeCode))
                return Fail("ERR013", "SubGrade Code is required.");
            if (string.IsNullOrWhiteSpace(dto.SubGradeName))
                return Fail("ERR014", "SubGrade Name is required.");

            return await _repository.SetSubGradesAsync(common);
        }

        public Task<BeanzResponseDTO> PostSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostSubGradesAsync(common);
        }

        public Task<BeanzResponseDTO> DelSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelSubGradesAsync(common);
        }

        public Task<SubGradeViewModel> GetInfoSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new SubGradeViewModel());
            return _repository.GetInfoSubGradesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpSubGradesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpSubGradesAsync(lookup);

        public Task<SubGradeViewModel> PrintSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new SubGradeViewModel());
            return _repository.PrintSubGradesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveSubGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveSubGradesAsync(common);
        }
    }
}
