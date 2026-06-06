using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeDependentRepository
    {
        Task<List<EmployeeDependentDTO>> GetEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeDependentsAsync(BeanzCommonDTO lookup);
        Task<EmployeeDependentViewModel> GetInfoEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<EmployeeDependentViewModel> PrintEmployeeDependentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeDependentsAsync(BeanzCommonDTO common);
    }
}
