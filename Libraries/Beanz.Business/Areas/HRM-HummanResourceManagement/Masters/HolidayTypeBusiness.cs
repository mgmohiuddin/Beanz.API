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
    public class HolidayTypeBusiness : IHolidayTypeBusiness
    {
        private readonly IHolidayTypeRepository _repository;

        public HolidayTypeBusiness(IHolidayTypeRepository repository)
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
        public Task<List<HolidayTypeDTO>> GetHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<HolidayTypeDTO>());
            return _repository.GetHolidayTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            HolidayTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<HolidayTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.HolidayTypeCode))
                return Fail("ERR013", "HolidayType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.HolidayTypeName))
                return Fail("ERR014", "HolidayType Name is required.");

            return await _repository.SetHolidayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostHolidayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelHolidayTypesAsync(common);
        }

        public Task<HolidayTypeViewModel> GetInfoHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new HolidayTypeViewModel());
            return _repository.GetInfoHolidayTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpHolidayTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpHolidayTypesAsync(lookup);

        public Task<HolidayTypeViewModel> PrintHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new HolidayTypeViewModel());
            return _repository.PrintHolidayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveHolidayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveHolidayTypesAsync(common);
        }
    }
}
