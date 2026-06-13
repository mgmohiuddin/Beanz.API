using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeCalendarRepository
    {
        Task<List<EmployeeCalendarDTO>> GetEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarsAsync(BeanzCommonDTO lookup);
        Task<EmployeeCalendarViewModel> GetInfoEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<EmployeeCalendarViewModel> PrintEmployeeCalendarsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeCalendarsAsync(BeanzCommonDTO common);
    }
}
