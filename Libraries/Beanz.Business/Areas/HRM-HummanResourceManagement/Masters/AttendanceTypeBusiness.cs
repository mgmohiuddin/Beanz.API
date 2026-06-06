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
    public class AttendanceTypeBusiness : IAttendanceTypeBusiness
    {
        private readonly IAttendanceTypeRepository _repository;

        public AttendanceTypeBusiness(IAttendanceTypeRepository repository)
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
        public Task<List<AttendanceTypeDTO>> GetAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AttendanceTypeDTO>());
            return _repository.GetAttendanceTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AttendanceTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AttendanceTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AttendanceTypeCode))
                return Fail("ERR013", "AttendanceType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AttendanceTypeName))
                return Fail("ERR014", "AttendanceType Name is required.");

            return await _repository.SetAttendanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAttendanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAttendanceTypesAsync(common);
        }

        public Task<AttendanceTypeViewModel> GetInfoAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AttendanceTypeViewModel());
            return _repository.GetInfoAttendanceTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAttendanceTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAttendanceTypesAsync(lookup);

        public Task<AttendanceTypeViewModel> PrintAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AttendanceTypeViewModel());
            return _repository.PrintAttendanceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAttendanceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAttendanceTypesAsync(common);
        }
    }
}
