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
    public class RelationTypeBusiness : IRelationTypeBusiness
    {
        private readonly IRelationTypeRepository _repository;

        public RelationTypeBusiness(IRelationTypeRepository repository)
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
        public Task<List<RelationTypeDTO>> GetRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<RelationTypeDTO>());
            return _repository.GetRelationTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            RelationTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<RelationTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.RelationTypeCode))
                return Fail("ERR013", "RelationType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.RelationTypeName))
                return Fail("ERR014", "RelationType Name is required.");

            return await _repository.SetRelationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostRelationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelRelationTypesAsync(common);
        }

        public Task<RelationTypeViewModel> GetInfoRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new RelationTypeViewModel());
            return _repository.GetInfoRelationTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpRelationTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpRelationTypesAsync(lookup);

        public Task<RelationTypeViewModel> PrintRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new RelationTypeViewModel());
            return _repository.PrintRelationTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveRelationTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveRelationTypesAsync(common);
        }
    }
}
