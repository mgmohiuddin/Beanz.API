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
    public class AllowancesGroupBusiness : IAllowancesGroupBusiness
    {
        private readonly IAllowancesGroupRepository _repository;

        public AllowancesGroupBusiness(IAllowancesGroupRepository repository)
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
        public Task<List<AllowancesGroupDTO>> GetAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AllowancesGroupDTO>());
            return _repository.GetAllowancesGroupsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AllowancesGroupDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AllowancesGroupDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AllowancesGroupCode))
                return Fail("ERR013", "AllowancesGroup Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AllowancesGroupName))
                return Fail("ERR014", "AllowancesGroup Name is required.");

            return await _repository.SetAllowancesGroupsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAllowancesGroupsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAllowancesGroupsAsync(common);
        }

        public Task<AllowancesGroupViewModel> GetInfoAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AllowancesGroupViewModel());
            return _repository.GetInfoAllowancesGroupsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAllowancesGroupsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAllowancesGroupsAsync(lookup);

        public Task<AllowancesGroupViewModel> PrintAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AllowancesGroupViewModel());
            return _repository.PrintAllowancesGroupsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAllowancesGroupsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAllowancesGroupsAsync(common);
        }
    }
}
