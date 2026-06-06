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
    public class TrainingTypeBusiness : ITrainingTypeBusiness
    {
        private readonly ITrainingTypeRepository _repository;

        public TrainingTypeBusiness(ITrainingTypeRepository repository)
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
        public Task<List<TrainingTypeDTO>> GetTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<TrainingTypeDTO>());
            return _repository.GetTrainingTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            TrainingTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<TrainingTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.TrainingTypeCode))
                return Fail("ERR013", "TrainingType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.TrainingTypeName))
                return Fail("ERR014", "TrainingType Name is required.");

            return await _repository.SetTrainingTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostTrainingTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelTrainingTypesAsync(common);
        }

        public Task<TrainingTypeViewModel> GetInfoTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new TrainingTypeViewModel());
            return _repository.GetInfoTrainingTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpTrainingTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpTrainingTypesAsync(lookup);

        public Task<TrainingTypeViewModel> PrintTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new TrainingTypeViewModel());
            return _repository.PrintTrainingTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveTrainingTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveTrainingTypesAsync(common);
        }
    }
}
