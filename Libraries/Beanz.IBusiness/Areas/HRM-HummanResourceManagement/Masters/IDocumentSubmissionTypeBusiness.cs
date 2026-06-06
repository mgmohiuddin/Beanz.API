using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IDocumentSubmissionTypeBusiness
    {
        Task<List<DocumentSubmissionTypeDTO>> GetDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<DocumentSubmissionTypeViewModel> GetInfoDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDocumentSubmissionTypesAsync(BeanzCommonDTO lookup);
        Task<DocumentSubmissionTypeViewModel> PrintDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDocumentSubmissionTypesAsync(BeanzCommonDTO common);
    }
}
