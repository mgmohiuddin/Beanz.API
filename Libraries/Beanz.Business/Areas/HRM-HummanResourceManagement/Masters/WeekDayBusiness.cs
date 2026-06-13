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
    public class WeekDayBusiness : IWeekDayBusiness
    {
        private readonly IWeekDayRepository _repository;

        public WeekDayBusiness(IWeekDayRepository repository)
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
        public Task<List<WeekDayDTO>> GetWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<WeekDayDTO>());
            return _repository.GetWeekDaysAsync(common);
        }

        public async Task<BeanzResponseDTO> SetWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            WeekDayDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<WeekDayDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.WeekDayCode))
                return Fail("ERR013", "WeekDay Code is required.");
            if (string.IsNullOrWhiteSpace(dto.WeekDayName))
                return Fail("ERR014", "WeekDay Name is required.");

            return await _repository.SetWeekDaysAsync(common);
        }

        public Task<BeanzResponseDTO> PostWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostWeekDaysAsync(common);
        }

        public Task<BeanzResponseDTO> DelWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelWeekDaysAsync(common);
        }

        public Task<WeekDayViewModel> GetInfoWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new WeekDayViewModel());
            return _repository.GetInfoWeekDaysAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpWeekDaysAsync(BeanzCommonDTO lookup)
            => _repository.LookUpWeekDaysAsync(lookup);

        public Task<WeekDayViewModel> PrintWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new WeekDayViewModel());
            return _repository.PrintWeekDaysAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveWeekDaysAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveWeekDaysAsync(common);
        }
    }
}
