using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IPayrollPolicyEligibleRepository
    {
        Task<List<PayrollPolicyEligibleDTO>> GetPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<PayrollPolicyEligibleViewModel> GetInfoPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<PayrollPolicyEligibleViewModel> PrintPayrollPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
