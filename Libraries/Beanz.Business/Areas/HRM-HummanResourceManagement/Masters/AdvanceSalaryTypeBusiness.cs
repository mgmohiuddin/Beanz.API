using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AdvanceSalaryTypeBusiness
    {
        private readonly IAdvanceSalaryTypeRepository _repository;

        public AdvanceSalaryTypeBusiness(IAdvanceSalaryTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AdvanceSalaryTypeDTO>> GetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.GetAdvanceSalaryTypesAsync(common);

        public Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.SetAdvanceSalaryTypesAsync(common);

        public Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.PostAdvanceSalaryTypesAsync(common);

        public Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.DelAdvanceSalaryTypesAsync(common);

        public Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAdvanceSalaryTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveAdvanceSalaryTypesAsync(common);
    }
}
