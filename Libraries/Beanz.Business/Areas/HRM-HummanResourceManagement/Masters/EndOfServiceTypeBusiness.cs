using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class EndOfServiceTypeBusiness
    {
        private readonly IEndOfServiceTypeRepository _repository;

        public EndOfServiceTypeBusiness(IEndOfServiceTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServiceTypeDTO>> GetEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServiceTypesAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServiceTypesAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServiceTypesAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServiceTypesAsync(common);

        public Task<EndOfServiceTypeViewModel> GetInfoEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServiceTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServiceTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServiceTypesAsync(common);
    }
}
