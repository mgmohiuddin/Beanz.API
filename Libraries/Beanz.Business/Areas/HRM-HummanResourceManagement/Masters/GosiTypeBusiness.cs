using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class GosiTypeBusiness
    {
        private readonly IGosiTypeRepository _repository;

        public GosiTypeBusiness(IGosiTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GosiTypeDTO>> GetGosiTypesAsync(BeanzCommonDTO common)
            => _repository.GetGosiTypesAsync(common);

        public Task<BeanzResponseDTO> SetGosiTypesAsync(BeanzCommonDTO common)
            => _repository.SetGosiTypesAsync(common);

        public Task<BeanzResponseDTO> PostGosiTypesAsync(BeanzCommonDTO common)
            => _repository.PostGosiTypesAsync(common);

        public Task<BeanzResponseDTO> DelGosiTypesAsync(BeanzCommonDTO common)
            => _repository.DelGosiTypesAsync(common);

        public Task<GosiTypeViewModel> GetInfoGosiTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoGosiTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveGosiTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveGosiTypesAsync(common);
    }
}
