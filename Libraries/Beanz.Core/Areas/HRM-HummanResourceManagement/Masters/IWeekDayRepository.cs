using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IWeekDayRepository
    {
        Task<List<WeekDayDTO>> GetWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelWeekDaysAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpWeekDaysAsync(BeanzCommonDTO lookup);
        Task<WeekDayViewModel> GetInfoWeekDaysAsync(BeanzCommonDTO common);
        Task<WeekDayViewModel> PrintWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveWeekDaysAsync(BeanzCommonDTO common);
    }
}
