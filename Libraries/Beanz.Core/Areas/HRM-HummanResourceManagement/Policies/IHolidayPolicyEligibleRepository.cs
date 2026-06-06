using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IHolidayPolicyEligibleRepository
    {
        Task<List<HolidayPolicyEligibleDTO>> GetHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<HolidayPolicyEligibleViewModel> GetInfoHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<HolidayPolicyEligibleViewModel> PrintHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
