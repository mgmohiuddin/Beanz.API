using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ILeavePolicieRepository
    {
        Task<List<LeavePolicieDTO>> GetLeavePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLeavePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLeavePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLeavePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLeavePoliciesAsync(BeanzCommonDTO lookup);
        Task<LeavePolicieViewModel> GetInfoLeavePoliciesAsync(BeanzCommonDTO common);
        Task<LeavePolicieViewModel> PrintLeavePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLeavePoliciesAsync(BeanzCommonDTO common);
    }
}
