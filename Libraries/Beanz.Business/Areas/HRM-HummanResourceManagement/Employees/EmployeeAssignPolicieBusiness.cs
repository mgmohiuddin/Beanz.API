using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeAssignPolicieBusiness
    {
        private readonly IEmployeeAssignPolicieRepository _repository;

        public EmployeeAssignPolicieBusiness(IEmployeeAssignPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeAssignPolicieDTO>> GetEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeAssignPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeAssignPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeAssignPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeAssignPoliciesAsync(common);

        public Task<EmployeeAssignPolicieViewModel> GetInfoEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeAssignPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeAssignPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeAssignPoliciesAsync(common);
    }
}
