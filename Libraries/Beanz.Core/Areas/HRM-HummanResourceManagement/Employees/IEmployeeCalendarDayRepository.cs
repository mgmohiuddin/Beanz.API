using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeCalendarDayRepository
    {
        Task<List<EmployeeCalendarDayDTO>> GetEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarDaysAsync(BeanzCommonDTO lookup);
        Task<EmployeeCalendarDayViewModel> GetInfoEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<EmployeeCalendarDayViewModel> PrintEmployeeCalendarDaysAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeCalendarDaysAsync(BeanzCommonDTO common);
    }
}
