using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Transactions
{
    public interface ILeaveOpeningBalanceRepository
    {
        Task<List<LeaveOpeningBalanceDTO>> GetLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeaveOpeningBalancesAsync(BeanzCommonDTO lookup);
        Task<LeaveOpeningBalanceViewModel> GetInfoLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<LeaveOpeningBalanceViewModel> PrintLeaveOpeningBalancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeaveOpeningBalancesAsync(BeanzCommonDTO common);
    }
}
