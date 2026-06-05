using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class RelationTypeBusiness
    {
        private readonly IRelationTypeRepository _repository;

        public RelationTypeBusiness(IRelationTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<RelationTypeDTO>> GetRelationTypesAsync(BeanzCommonDTO common)
            => _repository.GetRelationTypesAsync(common);

        public Task<BeanzResponseDTO> SetRelationTypesAsync(BeanzCommonDTO common)
            => _repository.SetRelationTypesAsync(common);

        public Task<BeanzResponseDTO> PostRelationTypesAsync(BeanzCommonDTO common)
            => _repository.PostRelationTypesAsync(common);

        public Task<BeanzResponseDTO> DelRelationTypesAsync(BeanzCommonDTO common)
            => _repository.DelRelationTypesAsync(common);

        public Task<RelationTypeViewModel> GetInfoRelationTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoRelationTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveRelationTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveRelationTypesAsync(common);
    }
}
