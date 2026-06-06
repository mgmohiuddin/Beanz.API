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
    public class ShiftTypeBusiness : IShiftTypeBusiness
    {
        private readonly IShiftTypeRepository _repository;

        public ShiftTypeBusiness(IShiftTypeRepository repository)
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
        public Task<List<ShiftTypeDTO>> GetShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<ShiftTypeDTO>());
            return _repository.GetShiftTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            ShiftTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<ShiftTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.ShiftTypeCode))
                return Fail("ERR013", "ShiftType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.ShiftTypeName))
                return Fail("ERR014", "ShiftType Name is required.");

            return await _repository.SetShiftTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostShiftTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelShiftTypesAsync(common);
        }

        public Task<ShiftTypeViewModel> GetInfoShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new ShiftTypeViewModel());
            return _repository.GetInfoShiftTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpShiftTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpShiftTypesAsync(lookup);

        public Task<ShiftTypeViewModel> PrintShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new ShiftTypeViewModel());
            return _repository.PrintShiftTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveShiftTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveShiftTypesAsync(common);
        }
    }
}
