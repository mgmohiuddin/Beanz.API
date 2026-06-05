using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class BusinessTripPolicieBusiness
    {
        private readonly IBusinessTripPolicieRepository _repository;

        public BusinessTripPolicieBusiness(IBusinessTripPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BusinessTripPolicieDTO>> GetBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetBusinessTripPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetBusinessTripPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostBusinessTripPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelBusinessTripPoliciesAsync(common);

        public Task<BusinessTripPolicieViewModel> GetInfoBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBusinessTripPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveBusinessTripPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveBusinessTripPoliciesAsync(common);
    }
}
