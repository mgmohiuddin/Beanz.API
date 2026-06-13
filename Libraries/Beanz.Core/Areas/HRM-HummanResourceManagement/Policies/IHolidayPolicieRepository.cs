using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IHolidayPolicieRepository
    {
        Task<List<HolidayPolicieDTO>> GetHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayPoliciesAsync(BeanzCommonDTO lookup);
        Task<HolidayPolicieViewModel> GetInfoHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<HolidayPolicieViewModel> PrintHolidayPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayPoliciesAsync(BeanzCommonDTO common);
    }
}
