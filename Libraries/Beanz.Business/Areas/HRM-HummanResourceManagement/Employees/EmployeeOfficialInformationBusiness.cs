using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeOfficialInformationBusiness
    {
        private readonly IEmployeeOfficialInformationRepository _repository;

        public EmployeeOfficialInformationBusiness(IEmployeeOfficialInformationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeOfficialInformationDTO>> GetEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeOfficialInformationsAsync(common);

        public Task<EmployeeOfficialInformationViewModel> GetInfoEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeOfficialInformationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeOfficialInformationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeOfficialInformationsAsync(common);
    }
}
