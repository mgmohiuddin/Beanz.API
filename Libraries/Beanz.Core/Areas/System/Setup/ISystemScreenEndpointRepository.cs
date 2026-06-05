using Beanz.DTOs.Areas.System.Setup;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.System.Setup
{
    public interface ISystemScreenEndpointRepository
    {
        Task<List<SystemScreenEndpointDTO>> GetSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSystemScreenEndpointsAsync(BeanzCommonDTO lookup);
        Task<SystemScreenEndpointViewModel> GetInfoSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<SystemScreenEndpointViewModel> PrintSystemScreenEndpointsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSystemScreenEndpointsAsync(BeanzCommonDTO common);
    }
}
