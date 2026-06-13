using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IDocumentTypeRepository
    {
        Task<List<DocumentTypeDTO>> GetDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDocumentTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDocumentTypesAsync(BeanzCommonDTO lookup);
        Task<DocumentTypeViewModel> GetInfoDocumentTypesAsync(BeanzCommonDTO common);
        Task<DocumentTypeViewModel> PrintDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDocumentTypesAsync(BeanzCommonDTO common);
    }
}
