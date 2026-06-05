using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeContractBusiness
    {
        private readonly IEmployeeContractRepository _repository;

        public EmployeeContractBusiness(IEmployeeContractRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeContractDTO>> GetEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeContractsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeContractsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeContractsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeContractsAsync(common);

        public Task<EmployeeContractViewModel> GetInfoEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeContractsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeContractsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeContractsAsync(common);
    }
}
