using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IVacationPolicieRepository
    {
        Task<List<VacationPolicieDTO>> GetVacationPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVacationPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVacationPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVacationPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVacationPoliciesAsync(BeanzCommonDTO lookup);
        Task<VacationPolicieViewModel> GetInfoVacationPoliciesAsync(BeanzCommonDTO common);
        Task<VacationPolicieViewModel> PrintVacationPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVacationPoliciesAsync(BeanzCommonDTO common);
    }
}
