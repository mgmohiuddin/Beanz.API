using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeesAsync(BeanzCommonDTO lookup);
        Task<EmployeeViewModel> GetInfoEmployeesAsync(BeanzCommonDTO common);
        Task<EmployeeViewModel> PrintEmployeesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeesAsync(BeanzCommonDTO common);
    }
}
