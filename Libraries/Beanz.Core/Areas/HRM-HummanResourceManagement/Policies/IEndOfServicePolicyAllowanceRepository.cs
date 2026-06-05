using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IEndOfServicePolicyAllowanceRepository
    {
        Task<List<EndOfServicePolicyAllowanceDTO>> GetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyAllowancesAsync(BeanzCommonDTO lookup);
        Task<EndOfServicePolicyAllowanceViewModel> GetInfoEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<EndOfServicePolicyAllowanceViewModel> PrintEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common);
    }
}
