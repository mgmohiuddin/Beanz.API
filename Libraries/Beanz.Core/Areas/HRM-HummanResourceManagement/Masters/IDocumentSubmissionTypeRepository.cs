using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IDocumentSubmissionTypeRepository
    {
        Task<List<DocumentSubmissionTypeDTO>> GetDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDocumentSubmissionTypesAsync(BeanzCommonDTO lookup);
        Task<DocumentSubmissionTypeViewModel> GetInfoDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<DocumentSubmissionTypeViewModel> PrintDocumentSubmissionTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDocumentSubmissionTypesAsync(BeanzCommonDTO common);
    }
}
