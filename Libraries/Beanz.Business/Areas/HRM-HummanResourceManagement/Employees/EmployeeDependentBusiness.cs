using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeDependentBusiness
    {
        private readonly IEmployeeDependentRepository _repository;

        public EmployeeDependentBusiness(IEmployeeDependentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeDependentDTO>> GetEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeDependentsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeDependentsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeDependentsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeDependentsAsync(common);

        public Task<EmployeeDependentViewModel> GetInfoEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeDependentsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeDependentsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeDependentsAsync(common);
    }
}
