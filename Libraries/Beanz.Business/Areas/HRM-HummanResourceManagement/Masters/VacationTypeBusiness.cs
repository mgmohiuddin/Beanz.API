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
    public class VacationTypeBusiness : IVacationTypeBusiness
    {
        private readonly IVacationTypeRepository _repository;

        public VacationTypeBusiness(IVacationTypeRepository repository)
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
        public Task<List<VacationTypeDTO>> GetVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<VacationTypeDTO>());
            return _repository.GetVacationTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            VacationTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<VacationTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.VacationTypeCode))
                return Fail("ERR013", "VacationType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.VacationTypeName))
                return Fail("ERR014", "VacationType Name is required.");

            return await _repository.SetVacationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostVacationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelVacationTypesAsync(common);
        }

        public Task<VacationTypeViewModel> GetInfoVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new VacationTypeViewModel());
            return _repository.GetInfoVacationTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpVacationTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpVacationTypesAsync(lookup);

        public Task<VacationTypeViewModel> PrintVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new VacationTypeViewModel());
            return _repository.PrintVacationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveVacationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveVacationTypesAsync(common);
        }
    }
}
