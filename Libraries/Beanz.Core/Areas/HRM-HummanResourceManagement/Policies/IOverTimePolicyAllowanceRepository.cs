using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IOverTimePolicyAllowanceRepository
    {
        Task<List<OverTimePolicyAllowanceDTO>> GetOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOverTimePolicyAllowancesAsync(BeanzCommonDTO lookup);
        Task<OverTimePolicyAllowanceViewModel> GetInfoOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<OverTimePolicyAllowanceViewModel> PrintOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOverTimePolicyAllowancesAsync(BeanzCommonDTO common);
    }
}
