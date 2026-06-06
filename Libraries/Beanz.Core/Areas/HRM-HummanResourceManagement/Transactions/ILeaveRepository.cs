using Beanz.DTOs.Areas.HummanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Transactions
{
    public interface ILeaveRepository
    {
        Task<List<LeaveDTO>> GetLeavesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeavesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeavesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeavesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeavesAsync(BeanzCommonDTO lookup);
        Task<LeaveViewModel> GetInfoLeavesAsync(BeanzCommonDTO common);
        Task<LeaveViewModel> PrintLeavesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeavesAsync(BeanzCommonDTO common);
    }
}
