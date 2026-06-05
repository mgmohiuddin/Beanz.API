using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class DocumentSubmissionTypeBusiness
    {
        private readonly IDocumentSubmissionTypeRepository _repository;

        public DocumentSubmissionTypeBusiness(IDocumentSubmissionTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<DocumentSubmissionTypeDTO>> GetDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.GetDocumentSubmissionTypesAsync(common);

        public Task<BeanzResponseDTO> SetDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.SetDocumentSubmissionTypesAsync(common);

        public Task<BeanzResponseDTO> PostDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.PostDocumentSubmissionTypesAsync(common);

        public Task<BeanzResponseDTO> DelDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.DelDocumentSubmissionTypesAsync(common);

        public Task<DocumentSubmissionTypeViewModel> GetInfoDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoDocumentSubmissionTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveDocumentSubmissionTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveDocumentSubmissionTypesAsync(common);
    }
}
