using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IBusinessTripTypeBusiness
    {
        Task<List<BusinessTripTypeDTO>> GetBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BusinessTripTypeViewModel> GetInfoBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripTypesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripTypeViewModel> PrintBusinessTripTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripTypesAsync(BeanzCommonDTO common);
    }
}
