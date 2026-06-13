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
    public class GradeBusiness : IGradeBusiness
    {
        private readonly IGradeRepository _repository;

        public GradeBusiness(IGradeRepository repository)
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
        public Task<List<GradeDTO>> GetGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<GradeDTO>());
            return _repository.GetGradesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            GradeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<GradeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.GradeCode))
                return Fail("ERR013", "Grade Code is required.");
            if (string.IsNullOrWhiteSpace(dto.GradeName))
                return Fail("ERR014", "Grade Name is required.");

            return await _repository.SetGradesAsync(common);
        }

        public Task<BeanzResponseDTO> PostGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostGradesAsync(common);
        }

        public Task<BeanzResponseDTO> DelGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelGradesAsync(common);
        }

        public Task<GradeViewModel> GetInfoGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new GradeViewModel());
            return _repository.GetInfoGradesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpGradesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpGradesAsync(lookup);

        public Task<GradeViewModel> PrintGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new GradeViewModel());
            return _repository.PrintGradesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveGradesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveGradesAsync(common);
        }
    }
}
