using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IBusinessTripPayTypeRepository
    {
        Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripPayTypesAsync(BeanzCommonDTO lookup);
        Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BusinessTripPayTypeViewModel> PrintBusinessTripPayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripPayTypesAsync(BeanzCommonDTO common);
    }
}
