using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceRepository
    {
        Task<List<AllowanceDTO>> GetAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancesAsync(BeanzCommonDTO lookup);
        Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzCommonDTO common);
        Task<AllowanceViewModel> PrintAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzCommonDTO common);
    }
}
