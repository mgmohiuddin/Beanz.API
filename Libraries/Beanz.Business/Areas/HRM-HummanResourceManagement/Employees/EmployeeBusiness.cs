using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeBusiness
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBusiness(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeDTO>> GetEmployeesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeesAsync(common);

        public Task<EmployeeViewModel> GetInfoEmployeesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeesAsync(common);
    }
}
