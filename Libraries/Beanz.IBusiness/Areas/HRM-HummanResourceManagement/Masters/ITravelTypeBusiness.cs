using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface ITravelTypeBusiness
    {
        Task<List<TravelTypeDTO>> GetTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTravelTypesAsync(BeanzCommonDTO common);
        Task<TravelTypeViewModel> GetInfoTravelTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTravelTypesAsync(BeanzCommonDTO lookup);
        Task<TravelTypeViewModel> PrintTravelTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTravelTypesAsync(BeanzCommonDTO common);
    }
}
