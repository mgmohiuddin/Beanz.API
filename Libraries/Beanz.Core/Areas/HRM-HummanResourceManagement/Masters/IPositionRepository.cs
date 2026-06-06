using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IPositionRepository
    {
        Task<List<PositionDTO>> GetPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPositionsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPositionsAsync(BeanzCommonDTO lookup);
        Task<PositionViewModel> GetInfoPositionsAsync(BeanzCommonDTO common);
        Task<PositionViewModel> PrintPositionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePositionsAsync(BeanzCommonDTO common);
    }
}
