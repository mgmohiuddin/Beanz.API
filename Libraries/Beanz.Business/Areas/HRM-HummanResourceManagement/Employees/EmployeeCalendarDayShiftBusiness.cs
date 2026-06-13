using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeCalendarDayShiftBusiness
    {
        private readonly IEmployeeCalendarDayShiftRepository _repository;

        public EmployeeCalendarDayShiftBusiness(IEmployeeCalendarDayShiftRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeCalendarDayShiftDTO>> GetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeCalendarDayShiftsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeCalendarDayShiftsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeCalendarDayShiftsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeCalendarDayShiftsAsync(common);

        public Task<EmployeeCalendarDayShiftViewModel> GetInfoEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeCalendarDayShiftsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeCalendarDayShiftsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeCalendarDayShiftsAsync(common);
    }
}
