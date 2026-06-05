using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Statuses;
using Beanz.DTOs.Areas.HummanResourceManagement.Statuses;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Statuses
{
    public class EmployeeContractStatuseBusiness
    {
        private readonly IEmployeeContractStatuseRepository _repository;

        public EmployeeContractStatuseBusiness(IEmployeeContractStatuseRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeContractStatuseDTO>> GetEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeContractStatusesAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeContractStatusesAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeContractStatusesAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeContractStatusesAsync(common);

        public Task<EmployeeContractStatuseViewModel> GetInfoEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeContractStatusesAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeContractStatusesAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeContractStatusesAsync(common);
    }
}
