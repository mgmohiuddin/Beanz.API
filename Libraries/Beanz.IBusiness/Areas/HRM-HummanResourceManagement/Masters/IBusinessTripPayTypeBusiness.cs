using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IBusinessTripPayTypeBusiness
    {
        Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripPayTypesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripPayTypeViewModel> PrintBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripPayTypesAsync(BeanzCommonDTO common);
    }
}
