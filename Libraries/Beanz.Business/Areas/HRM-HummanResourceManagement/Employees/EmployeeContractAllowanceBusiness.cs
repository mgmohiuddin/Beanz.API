using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeContractAllowanceBusiness
    {
        private readonly IEmployeeContractAllowanceRepository _repository;

        public EmployeeContractAllowanceBusiness(IEmployeeContractAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeContractAllowanceDTO>> GetEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeContractAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeContractAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeContractAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeContractAllowancesAsync(common);

        public Task<EmployeeContractAllowanceViewModel> GetInfoEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeContractAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeContractAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeContractAllowancesAsync(common);
    }
}
