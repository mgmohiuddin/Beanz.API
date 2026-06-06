using Beanz.DTOs.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.BeanzSystem.Setup
{
    public interface ISystemModuleRepository
    {
        Task<List<SystemModuleDTO>> GetSystemModulesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSystemModulesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSystemModulesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSystemModulesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSystemModulesAsync(BeanzCommonDTO lookup);
        Task<SystemModuleViewModel> GetInfoSystemModulesAsync(BeanzCommonDTO common);
        Task<SystemModuleViewModel> PrintSystemModulesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSystemModulesAsync(BeanzCommonDTO common);
    }
}
