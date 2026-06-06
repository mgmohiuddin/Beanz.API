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
    public class ResidenceIDTypeBusiness : IResidenceIDTypeBusiness
    {
        private readonly IResidenceIDTypeRepository _repository;

        public ResidenceIDTypeBusiness(IResidenceIDTypeRepository repository)
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
        public Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<ResidenceIDTypeDTO>());
            return _repository.GetResidenceIDTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            ResidenceIDTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<ResidenceIDTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.ResidenceIDTypeCode))
                return Fail("ERR013", "ResidenceIDType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.ResidenceIDTypeName))
                return Fail("ERR014", "ResidenceIDType Name is required.");

            return await _repository.SetResidenceIDTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostResidenceIDTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelResidenceIDTypesAsync(common);
        }

        public Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new ResidenceIDTypeViewModel());
            return _repository.GetInfoResidenceIDTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpResidenceIDTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpResidenceIDTypesAsync(lookup);

        public Task<ResidenceIDTypeViewModel> PrintResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new ResidenceIDTypeViewModel());
            return _repository.PrintResidenceIDTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveResidenceIDTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveResidenceIDTypesAsync(common);
        }
    }
}
