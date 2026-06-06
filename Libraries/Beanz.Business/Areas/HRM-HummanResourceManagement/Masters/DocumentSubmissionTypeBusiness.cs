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
    public class DocumentSubmissionTypeBusiness : IDocumentSubmissionTypeBusiness
    {
        private readonly IDocumentSubmissionTypeRepository _repository;

        public DocumentSubmissionTypeBusiness(IDocumentSubmissionTypeRepository repository)
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
        public Task<List<DocumentSubmissionTypeDTO>> GetDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<DocumentSubmissionTypeDTO>());
            return _repository.GetDocumentSubmissionTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            DocumentSubmissionTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<DocumentSubmissionTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.DocumentSubmissionTypeCode))
                return Fail("ERR013", "DocumentSubmissionType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.DocumentSubmissionTypeName))
                return Fail("ERR014", "DocumentSubmissionType Name is required.");

            return await _repository.SetDocumentSubmissionTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostDocumentSubmissionTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelDocumentSubmissionTypesAsync(common);
        }

        public Task<DocumentSubmissionTypeViewModel> GetInfoDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new DocumentSubmissionTypeViewModel());
            return _repository.GetInfoDocumentSubmissionTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpDocumentSubmissionTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpDocumentSubmissionTypesAsync(lookup);

        public Task<DocumentSubmissionTypeViewModel> PrintDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new DocumentSubmissionTypeViewModel());
            return _repository.PrintDocumentSubmissionTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveDocumentSubmissionTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveDocumentSubmissionTypesAsync(common);
        }
    }
}
