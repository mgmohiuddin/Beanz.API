using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class DocumentTypeBusiness
    {
        private readonly IDocumentTypeRepository _repository;

        public DocumentTypeBusiness(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<DocumentTypeDTO>> GetDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.GetDocumentTypesAsync(common);

        public Task<BeanzResponseDTO> SetDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.SetDocumentTypesAsync(common);

        public Task<BeanzResponseDTO> PostDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.PostDocumentTypesAsync(common);

        public Task<BeanzResponseDTO> DelDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.DelDocumentTypesAsync(common);

        public Task<DocumentTypeViewModel> GetInfoDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoDocumentTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveDocumentTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveDocumentTypesAsync(common);
    }
}
