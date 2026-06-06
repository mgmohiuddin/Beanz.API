using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IShiftPolicieRepository
    {
        Task<List<ShiftPolicieDTO>> GetShiftPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetShiftPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostShiftPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelShiftPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpShiftPoliciesAsync(BeanzCommonDTO lookup);
        Task<ShiftPolicieViewModel> GetInfoShiftPoliciesAsync(BeanzCommonDTO common);
        Task<ShiftPolicieViewModel> PrintShiftPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveShiftPoliciesAsync(BeanzCommonDTO common);
    }
}
