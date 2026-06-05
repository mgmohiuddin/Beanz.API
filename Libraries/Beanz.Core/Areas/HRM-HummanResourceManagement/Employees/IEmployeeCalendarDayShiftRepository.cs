using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeCalendarDayShiftRepository
    {
        Task<List<EmployeeCalendarDayShiftDTO>> GetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarDayShiftsAsync(BeanzCommonDTO lookup);
        Task<EmployeeCalendarDayShiftViewModel> GetInfoEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<EmployeeCalendarDayShiftViewModel> PrintEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common);
    }
}
