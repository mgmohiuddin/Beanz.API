using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Employees
{
    public class EmployeeLanguageBusiness
    {
        private readonly IEmployeeLanguageRepository _repository;

        public EmployeeLanguageBusiness(IEmployeeLanguageRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeLanguageDTO>> GetEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeLanguagesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeLanguagesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeLanguagesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeLanguagesAsync(common);

        public Task<EmployeeLanguageViewModel> GetInfoEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeLanguagesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeLanguagesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeLanguagesAsync(common);
    }
}
