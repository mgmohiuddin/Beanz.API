using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeAllowanceRepository
    {
        Task<List<EmployeeAllowanceDTO>> GetEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeAllowancesAsync(BeanzCommonDTO lookup);
        Task<EmployeeAllowanceViewModel> GetInfoEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<EmployeeAllowanceViewModel> PrintEmployeeAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeAllowancesAsync(BeanzCommonDTO common);
    }
}
