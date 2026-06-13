using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Transactions
{
    public interface ILeaveDayRepository
    {
        Task<List<LeaveDayDTO>> GetLeaveDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeaveDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeaveDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeaveDaysAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeaveDaysAsync(BeanzCommonDTO lookup);
        Task<LeaveDayViewModel> GetInfoLeaveDaysAsync(BeanzCommonDTO common);
        Task<LeaveDayViewModel> PrintLeaveDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeaveDaysAsync(BeanzCommonDTO common);
    }
}
