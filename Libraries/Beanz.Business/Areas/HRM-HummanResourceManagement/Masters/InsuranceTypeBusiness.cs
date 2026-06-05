using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class InsuranceTypeBusiness
    {
        private readonly IInsuranceTypeRepository _repository;

        public InsuranceTypeBusiness(IInsuranceTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<InsuranceTypeDTO>> GetInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.GetInsuranceTypesAsync(common);

        public Task<BeanzResponseDTO> SetInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.SetInsuranceTypesAsync(common);

        public Task<BeanzResponseDTO> PostInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.PostInsuranceTypesAsync(common);

        public Task<BeanzResponseDTO> DelInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.DelInsuranceTypesAsync(common);

        public Task<InsuranceTypeViewModel> GetInfoInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoInsuranceTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveInsuranceTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveInsuranceTypesAsync(common);
    }
}
