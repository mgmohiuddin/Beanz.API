using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class TravelTypeBusiness
    {
        private readonly ITravelTypeRepository _repository;

        public TravelTypeBusiness(ITravelTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TravelTypeDTO>> GetTravelTypesAsync(BeanzCommonDTO common)
            => _repository.GetTravelTypesAsync(common);

        public Task<BeanzResponseDTO> SetTravelTypesAsync(BeanzCommonDTO common)
            => _repository.SetTravelTypesAsync(common);

        public Task<BeanzResponseDTO> PostTravelTypesAsync(BeanzCommonDTO common)
            => _repository.PostTravelTypesAsync(common);

        public Task<BeanzResponseDTO> DelTravelTypesAsync(BeanzCommonDTO common)
            => _repository.DelTravelTypesAsync(common);

        public Task<TravelTypeViewModel> GetInfoTravelTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTravelTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveTravelTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveTravelTypesAsync(common);
    }
}
