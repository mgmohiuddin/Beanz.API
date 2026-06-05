using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class BusinessTripPolicyPaymentBusiness
    {
        private readonly IBusinessTripPolicyPaymentRepository _repository;

        public BusinessTripPolicyPaymentBusiness(IBusinessTripPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BusinessTripPolicyPaymentDTO>> GetBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetBusinessTripPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetBusinessTripPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostBusinessTripPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelBusinessTripPolicyPaymentsAsync(common);

        public Task<BusinessTripPolicyPaymentViewModel> GetInfoBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoBusinessTripPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveBusinessTripPolicyPaymentsAsync(common);
    }
}
