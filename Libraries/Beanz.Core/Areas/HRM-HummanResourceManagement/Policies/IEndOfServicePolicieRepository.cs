using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IEndOfServicePolicieRepository
    {
        Task<List<EndOfServicePolicieDTO>> GetEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServicePoliciesAsync(BeanzCommonDTO lookup);
        Task<EndOfServicePolicieViewModel> GetInfoEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<EndOfServicePolicieViewModel> PrintEndOfServicePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServicePoliciesAsync(BeanzCommonDTO common);
    }
}
