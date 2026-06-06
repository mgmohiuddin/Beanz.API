using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IPayrollPolicieRepository
    {
        Task<List<PayrollPolicieDTO>> GetPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollPoliciesAsync(BeanzCommonDTO lookup);
        Task<PayrollPolicieViewModel> GetInfoPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<PayrollPolicieViewModel> PrintPayrollPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollPoliciesAsync(BeanzCommonDTO common);
    }
}
