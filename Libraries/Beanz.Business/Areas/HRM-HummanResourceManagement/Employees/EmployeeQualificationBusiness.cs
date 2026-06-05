using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeQualificationBusiness
    {
        private readonly IEmployeeQualificationRepository _repository;

        public EmployeeQualificationBusiness(IEmployeeQualificationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeQualificationDTO>> GetEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeQualificationsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeQualificationsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeQualificationsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeQualificationsAsync(common);

        public Task<EmployeeQualificationViewModel> GetInfoEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeQualificationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeQualificationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeQualificationsAsync(common);
    }
}
