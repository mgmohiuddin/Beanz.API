using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IGosiPolicieRepository
    {
        Task<List<GosiPolicieDTO>> GetGosiPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiPoliciesAsync(BeanzCommonDTO lookup);
        Task<GosiPolicieViewModel> GetInfoGosiPoliciesAsync(BeanzCommonDTO common);
        Task<GosiPolicieViewModel> PrintGosiPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiPoliciesAsync(BeanzCommonDTO common);
    }
}
