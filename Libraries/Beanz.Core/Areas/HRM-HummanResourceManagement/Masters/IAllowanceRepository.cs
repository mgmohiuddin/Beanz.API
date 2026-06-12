using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceRepository
    {
        Task<BeanzResponseObjectDTO<List<AllowanceDTO>>> GetAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> SetAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> PostAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> DelAllowancesAsync(BeanzRequestDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancesAsync(BeanzRequestDTO lookup);
        Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzRequestDTO common);
        Task<AllowanceViewModel> PrintAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzRequestDTO common);
    }
}
