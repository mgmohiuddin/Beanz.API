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
    public class DocumentTypeBusiness : IDocumentTypeBusiness
    {
        private readonly IDocumentTypeRepository _repository;

        public DocumentTypeBusiness(IDocumentTypeRepository repository)
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
        public Task<List<DocumentTypeDTO>> GetDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<DocumentTypeDTO>());
            return _repository.GetDocumentTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            DocumentTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<DocumentTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.DocumentTypeCode))
                return Fail("ERR013", "DocumentType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.DocumentTypeName))
                return Fail("ERR014", "DocumentType Name is required.");

            return await _repository.SetDocumentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostDocumentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelDocumentTypesAsync(common);
        }

        public Task<DocumentTypeViewModel> GetInfoDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new DocumentTypeViewModel());
            return _repository.GetInfoDocumentTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpDocumentTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpDocumentTypesAsync(lookup);

        public Task<DocumentTypeViewModel> PrintDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new DocumentTypeViewModel());
            return _repository.PrintDocumentTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveDocumentTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveDocumentTypesAsync(common);
        }
    }
}
