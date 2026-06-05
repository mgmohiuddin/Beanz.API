using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeFinancialInformationBusiness
    {
        private readonly IEmployeeFinancialInformationRepository _repository;

        public EmployeeFinancialInformationBusiness(IEmployeeFinancialInformationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeFinancialInformationDTO>> GetEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeFinancialInformationsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeFinancialInformationsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeFinancialInformationsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeFinancialInformationsAsync(common);

        public Task<EmployeeFinancialInformationViewModel> GetInfoEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeFinancialInformationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeFinancialInformationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeFinancialInformationsAsync(common);
    }
}
