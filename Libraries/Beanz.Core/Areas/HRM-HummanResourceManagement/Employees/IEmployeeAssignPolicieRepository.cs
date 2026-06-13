using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeAssignPolicieRepository
    {
        Task<List<EmployeeAssignPolicieDTO>> GetEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeAssignPoliciesAsync(BeanzCommonDTO lookup);
        Task<EmployeeAssignPolicieViewModel> GetInfoEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<EmployeeAssignPolicieViewModel> PrintEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeAssignPoliciesAsync(BeanzCommonDTO common);
    }
}
