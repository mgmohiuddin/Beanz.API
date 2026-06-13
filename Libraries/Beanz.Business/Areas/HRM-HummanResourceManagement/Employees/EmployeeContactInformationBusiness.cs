using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeContactInformationBusiness
    {
        private readonly IEmployeeContactInformationRepository _repository;

        public EmployeeContactInformationBusiness(IEmployeeContactInformationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeContactInformationDTO>> GetEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeContactInformationsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeContactInformationsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeContactInformationsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeContactInformationsAsync(common);

        public Task<EmployeeContactInformationViewModel> GetInfoEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeContactInformationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeContactInformationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeContactInformationsAsync(common);
    }
}
