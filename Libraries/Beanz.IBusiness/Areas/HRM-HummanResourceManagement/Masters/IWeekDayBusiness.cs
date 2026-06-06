using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IWeekDayBusiness
    {
        Task<List<WeekDayDTO>> GetWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelWeekDaysAsync(BeanzCommonDTO common);
        Task<WeekDayViewModel> GetInfoWeekDaysAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpWeekDaysAsync(BeanzCommonDTO lookup);
        Task<WeekDayViewModel> PrintWeekDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveWeekDaysAsync(BeanzCommonDTO common);
    }
}
