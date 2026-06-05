using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class BusinessTripTypeBusiness
    {
        private readonly IBusinessTripTypeRepository _repository;

        public BusinessTripTypeBusiness(IBusinessTripTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BusinessTripTypeDTO>> GetBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.GetBusinessTripTypesAsync(common);

        public Task<BeanzResponseDTO> SetBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.SetBusinessTripTypesAsync(common);

        public Task<BeanzResponseDTO> PostBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.PostBusinessTripTypesAsync(common);

        public Task<BeanzResponseDTO> DelBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.DelBusinessTripTypesAsync(common);

        public Task<BusinessTripTypeViewModel> GetInfoBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBusinessTripTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveBusinessTripTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveBusinessTripTypesAsync(common);
    }
}
