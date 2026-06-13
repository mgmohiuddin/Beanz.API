using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IBusinessTripTypeRepository
    {
        Task<List<BusinessTripTypeDTO>> GetBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripTypesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripTypeViewModel> GetInfoBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BusinessTripTypeViewModel> PrintBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripTypesAsync(BeanzCommonDTO common);
    }
}
