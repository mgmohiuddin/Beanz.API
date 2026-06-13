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
    public class DesignationBusiness : IDesignationBusiness
    {
        private readonly IDesignationRepository _repository;

        public DesignationBusiness(IDesignationRepository repository)
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
        public Task<List<DesignationDTO>> GetDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<DesignationDTO>());
            return _repository.GetDesignationsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            DesignationDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<DesignationDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.DesignationCode))
                return Fail("ERR013", "Designation Code is required.");
            if (string.IsNullOrWhiteSpace(dto.DesignationName))
                return Fail("ERR014", "Designation Name is required.");

            return await _repository.SetDesignationsAsync(common);
        }

        public Task<BeanzResponseDTO> PostDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostDesignationsAsync(common);
        }

        public Task<BeanzResponseDTO> DelDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelDesignationsAsync(common);
        }

        public Task<DesignationViewModel> GetInfoDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new DesignationViewModel());
            return _repository.GetInfoDesignationsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpDesignationsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpDesignationsAsync(lookup);

        public Task<DesignationViewModel> PrintDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new DesignationViewModel());
            return _repository.PrintDesignationsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveDesignationsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveDesignationsAsync(common);
        }
    }
}
