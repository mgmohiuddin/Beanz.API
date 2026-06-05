using Beanz.DTOs.Areas.System.Setup;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.System.Setup
{
    public interface ISystemScreenRepository
    {
        Task<List<SystemScreenDTO>> GetSystemScreensAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSystemScreensAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSystemScreensAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSystemScreensAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSystemScreensAsync(BeanzCommonDTO lookup);
        Task<SystemScreenViewModel> GetInfoSystemScreensAsync(BeanzCommonDTO common);
        Task<SystemScreenViewModel> PrintSystemScreensAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSystemScreensAsync(BeanzCommonDTO common);
    }
}
