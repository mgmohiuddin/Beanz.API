using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class PermitTypeBusiness
    {
        private readonly IPermitTypeRepository _repository;

        public PermitTypeBusiness(IPermitTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PermitTypeDTO>> GetPermitTypesAsync(BeanzCommonDTO common)
            => _repository.GetPermitTypesAsync(common);

        public Task<BeanzResponseDTO> SetPermitTypesAsync(BeanzCommonDTO common)
            => _repository.SetPermitTypesAsync(common);

        public Task<BeanzResponseDTO> PostPermitTypesAsync(BeanzCommonDTO common)
            => _repository.PostPermitTypesAsync(common);

        public Task<BeanzResponseDTO> DelPermitTypesAsync(BeanzCommonDTO common)
            => _repository.DelPermitTypesAsync(common);

        public Task<PermitTypeViewModel> GetInfoPermitTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPermitTypesAsync(common);

        public Task<BeanzResponseDTO> ApprovePermitTypesAsync(BeanzCommonDTO common)
            => _repository.ApprovePermitTypesAsync(common);
    }
}
