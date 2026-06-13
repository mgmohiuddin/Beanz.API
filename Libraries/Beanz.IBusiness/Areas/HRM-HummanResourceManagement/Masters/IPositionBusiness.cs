using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IPositionBusiness
    {
        Task<List<PositionDTO>> GetPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPositionsAsync(BeanzCommonDTO common);
        Task<PositionViewModel> GetInfoPositionsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPositionsAsync(BeanzCommonDTO lookup);
        Task<PositionViewModel> PrintPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePositionsAsync(BeanzCommonDTO common);
    }
}
