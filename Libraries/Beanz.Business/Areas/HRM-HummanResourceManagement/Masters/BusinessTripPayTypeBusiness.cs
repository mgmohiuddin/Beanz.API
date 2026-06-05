using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class BusinessTripPayTypeBusiness
    {
        private readonly IBusinessTripPayTypeRepository _repository;

        public BusinessTripPayTypeBusiness(IBusinessTripPayTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.GetBusinessTripPayTypesAsync(common);

        public Task<BeanzResponseDTO> SetBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.SetBusinessTripPayTypesAsync(common);

        public Task<BeanzResponseDTO> PostBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.PostBusinessTripPayTypesAsync(common);

        public Task<BeanzResponseDTO> DelBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.DelBusinessTripPayTypesAsync(common);

        public Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBusinessTripPayTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveBusinessTripPayTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveBusinessTripPayTypesAsync(common);
    }
}
