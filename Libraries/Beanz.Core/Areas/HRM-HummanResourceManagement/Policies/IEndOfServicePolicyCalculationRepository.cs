using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IEndOfServicePolicyCalculationRepository
    {
        Task<List<EndOfServicePolicyCalculationDTO>> GetEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyCalculationsAsync(BeanzCommonDTO lookup);
        Task<EndOfServicePolicyCalculationViewModel> GetInfoEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<EndOfServicePolicyCalculationViewModel> PrintEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common);
    }
}
