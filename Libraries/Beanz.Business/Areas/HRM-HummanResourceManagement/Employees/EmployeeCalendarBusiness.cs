using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeCalendarBusiness
    {
        private readonly IEmployeeCalendarRepository _repository;

        public EmployeeCalendarBusiness(IEmployeeCalendarRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeCalendarDTO>> GetEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeCalendarsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeCalendarsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeCalendarsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeCalendarsAsync(common);

        public Task<EmployeeCalendarViewModel> GetInfoEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeCalendarsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeCalendarsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeCalendarsAsync(common);
    }
}
