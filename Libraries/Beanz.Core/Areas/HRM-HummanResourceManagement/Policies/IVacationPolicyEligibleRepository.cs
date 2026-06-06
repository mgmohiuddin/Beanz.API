using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IVacationPolicyEligibleRepository
    {
        Task<List<VacationPolicyEligibleDTO>> GetVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVacationPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<VacationPolicyEligibleViewModel> GetInfoVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<VacationPolicyEligibleViewModel> PrintVacationPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVacationPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
