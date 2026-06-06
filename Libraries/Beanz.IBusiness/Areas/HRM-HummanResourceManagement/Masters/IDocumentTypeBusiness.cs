using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IDocumentTypeBusiness
    {
        Task<List<DocumentTypeDTO>> GetDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDocumentTypesAsync(BeanzCommonDTO common);
        Task<DocumentTypeViewModel> GetInfoDocumentTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDocumentTypesAsync(BeanzCommonDTO lookup);
        Task<DocumentTypeViewModel> PrintDocumentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDocumentTypesAsync(BeanzCommonDTO common);
    }
}
