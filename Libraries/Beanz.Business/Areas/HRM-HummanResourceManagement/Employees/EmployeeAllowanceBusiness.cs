using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeAllowanceBusiness
    {
        private readonly IEmployeeAllowanceRepository _repository;

        public EmployeeAllowanceBusiness(IEmployeeAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeAllowanceDTO>> GetEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeAllowancesAsync(common);

        public Task<EmployeeAllowanceViewModel> GetInfoEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeAllowancesAsync(common);
    }
}
