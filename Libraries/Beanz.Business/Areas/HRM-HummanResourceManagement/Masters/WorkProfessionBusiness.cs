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
    public class WorkProfessionBusiness : IWorkProfessionBusiness
    {
        private readonly IWorkProfessionRepository _repository;

        public WorkProfessionBusiness(IWorkProfessionRepository repository)
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
        public Task<List<WorkProfessionDTO>> GetWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<WorkProfessionDTO>());
            return _repository.GetWorkProfessionsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            WorkProfessionDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<WorkProfessionDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.WorkProfessionCode))
                return Fail("ERR013", "WorkProfession Code is required.");
            if (string.IsNullOrWhiteSpace(dto.WorkProfessionName))
                return Fail("ERR014", "WorkProfession Name is required.");

            return await _repository.SetWorkProfessionsAsync(common);
        }

        public Task<BeanzResponseDTO> PostWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostWorkProfessionsAsync(common);
        }

        public Task<BeanzResponseDTO> DelWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelWorkProfessionsAsync(common);
        }

        public Task<WorkProfessionViewModel> GetInfoWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new WorkProfessionViewModel());
            return _repository.GetInfoWorkProfessionsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpWorkProfessionsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpWorkProfessionsAsync(lookup);

        public Task<WorkProfessionViewModel> PrintWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new WorkProfessionViewModel());
            return _repository.PrintWorkProfessionsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveWorkProfessionsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveWorkProfessionsAsync(common);
        }
    }
}
