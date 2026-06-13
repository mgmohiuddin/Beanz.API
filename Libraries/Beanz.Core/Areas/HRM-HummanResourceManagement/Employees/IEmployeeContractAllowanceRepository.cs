using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeContractAllowanceRepository
    {
        Task<List<EmployeeContractAllowanceDTO>> GetEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeContractAllowancesAsync(BeanzCommonDTO lookup);
        Task<EmployeeContractAllowanceViewModel> GetInfoEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<EmployeeContractAllowanceViewModel> PrintEmployeeContractAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeContractAllowancesAsync(BeanzCommonDTO common);
    }
}
