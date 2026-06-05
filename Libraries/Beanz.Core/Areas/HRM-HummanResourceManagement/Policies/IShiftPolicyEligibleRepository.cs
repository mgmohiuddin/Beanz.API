using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IShiftPolicyEligibleRepository
    {
        Task<List<ShiftPolicyEligibleDTO>> GetShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpShiftPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<ShiftPolicyEligibleViewModel> GetInfoShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<ShiftPolicyEligibleViewModel> PrintShiftPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveShiftPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
