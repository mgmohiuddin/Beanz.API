using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ITravelTypeRepository
    {
        Task<List<TravelTypeDTO>> GetTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTravelTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTravelTypesAsync(BeanzCommonDTO lookup);
        Task<TravelTypeViewModel> GetInfoTravelTypesAsync(BeanzCommonDTO common);
        Task<TravelTypeViewModel> PrintTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTravelTypesAsync(BeanzCommonDTO common);
    }
}
