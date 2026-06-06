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
    public class LeaveTypeBusiness : ILeaveTypeBusiness
    {
        private readonly ILeaveTypeRepository _repository;

        public LeaveTypeBusiness(ILeaveTypeRepository repository)
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
        public Task<List<LeaveTypeDTO>> GetLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<LeaveTypeDTO>());
            return _repository.GetLeaveTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            LeaveTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<LeaveTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.LeaveTypeCode))
                return Fail("ERR013", "LeaveType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.LeaveTypeName))
                return Fail("ERR014", "LeaveType Name is required.");

            return await _repository.SetLeaveTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostLeaveTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelLeaveTypesAsync(common);
        }

        public Task<LeaveTypeViewModel> GetInfoLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new LeaveTypeViewModel());
            return _repository.GetInfoLeaveTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpLeaveTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpLeaveTypesAsync(lookup);

        public Task<LeaveTypeViewModel> PrintLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new LeaveTypeViewModel());
            return _repository.PrintLeaveTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveLeaveTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveLeaveTypesAsync(common);
        }
    }
}
