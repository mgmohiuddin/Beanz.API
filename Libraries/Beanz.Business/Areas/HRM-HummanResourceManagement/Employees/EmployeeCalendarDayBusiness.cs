using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeCalendarDayBusiness
    {
        private readonly IEmployeeCalendarDayRepository _repository;

        public EmployeeCalendarDayBusiness(IEmployeeCalendarDayRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeCalendarDayDTO>> GetEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeCalendarDaysAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeCalendarDaysAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeCalendarDaysAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeCalendarDaysAsync(common);

        public Task<EmployeeCalendarDayViewModel> GetInfoEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeCalendarDaysAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeCalendarDaysAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeCalendarDaysAsync(common);
    }
}
