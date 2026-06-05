using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class ResidenceIDTypeBusiness
    {
        private readonly IResidenceIDTypeRepository _repository;

        public ResidenceIDTypeBusiness(IResidenceIDTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.GetResidenceIDTypesAsync(common);

        public Task<BeanzResponseDTO> SetResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.SetResidenceIDTypesAsync(common);

        public Task<BeanzResponseDTO> PostResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.PostResidenceIDTypesAsync(common);

        public Task<BeanzResponseDTO> DelResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.DelResidenceIDTypesAsync(common);

        public Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoResidenceIDTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveResidenceIDTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveResidenceIDTypesAsync(common);
    }
}
