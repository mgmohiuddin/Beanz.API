using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class BusinessTripPolicyEligibleBusiness
    {
        private readonly IBusinessTripPolicyEligibleRepository _repository;

        public BusinessTripPolicyEligibleBusiness(IBusinessTripPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BusinessTripPolicyEligibleDTO>> GetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetBusinessTripPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetBusinessTripPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostBusinessTripPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelBusinessTripPolicyEligiblesAsync(common);

        public Task<BusinessTripPolicyEligibleViewModel> GetInfoBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBusinessTripPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveBusinessTripPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveBusinessTripPolicyEligiblesAsync(common);
    }
}
