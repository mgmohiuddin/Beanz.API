using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IHolidayPolicyDayRepository
    {
        Task<List<HolidayPolicyDayDTO>> GetHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayPolicyDaysAsync(BeanzCommonDTO lookup);
        Task<HolidayPolicyDayViewModel> GetInfoHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<HolidayPolicyDayViewModel> PrintHolidayPolicyDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayPolicyDaysAsync(BeanzCommonDTO common);
    }
}
