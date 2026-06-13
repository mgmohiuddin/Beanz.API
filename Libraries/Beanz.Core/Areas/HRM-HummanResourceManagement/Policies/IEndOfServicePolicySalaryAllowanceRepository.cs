using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IEndOfServicePolicySalaryAllowanceRepository
    {
        Task<List<EndOfServicePolicySalaryAllowanceDTO>> GetEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO lookup);
        Task<EndOfServicePolicySalaryAllowanceViewModel> GetInfoEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<EndOfServicePolicySalaryAllowanceViewModel> PrintEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common);
    }
}
