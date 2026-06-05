using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IPaidTimeOffPolicieRepository
    {
        Task<List<PaidTimeOffPolicieDTO>> GetPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaidTimeOffPoliciesAsync(BeanzCommonDTO lookup);
        Task<PaidTimeOffPolicieViewModel> GetInfoPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<PaidTimeOffPolicieViewModel> PrintPaidTimeOffPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaidTimeOffPoliciesAsync(BeanzCommonDTO common);
    }
}
