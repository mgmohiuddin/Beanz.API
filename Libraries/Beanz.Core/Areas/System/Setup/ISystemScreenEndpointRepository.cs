using Beanz.DTOs.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.BeanzSystem.Setup
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
