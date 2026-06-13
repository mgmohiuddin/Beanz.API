using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeContractOfficialInformationBusiness
    {
        private readonly IEmployeeContractOfficialInformationRepository _repository;

        public EmployeeContractOfficialInformationBusiness(IEmployeeContractOfficialInformationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeContractOfficialInformationDTO>> GetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeContractOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeContractOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeContractOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeContractOfficialInformationsAsync(common);

        public Task<EmployeeContractOfficialInformationViewModel> GetInfoEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeContractOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeContractOfficialInformationsAsync(common);
    }
}
