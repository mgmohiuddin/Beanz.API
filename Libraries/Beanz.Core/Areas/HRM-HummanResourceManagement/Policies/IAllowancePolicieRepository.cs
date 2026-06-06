using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAllowancePolicieRepository
    {
        Task<List<AllowancePolicieDTO>> GetAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancePoliciesAsync(BeanzCommonDTO lookup);
        Task<AllowancePolicieViewModel> GetInfoAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<AllowancePolicieViewModel> PrintAllowancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancePoliciesAsync(BeanzCommonDTO common);
    }
}
