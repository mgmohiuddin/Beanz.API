using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class PaidTimeOffPolicyPaymentBusiness
    {
        private readonly IPaidTimeOffPolicyPaymentRepository _repository;

        public PaidTimeOffPolicyPaymentBusiness(IPaidTimeOffPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PaidTimeOffPolicyPaymentDTO>> GetPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetPaidTimeOffPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetPaidTimeOffPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostPaidTimeOffPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelPaidTimeOffPolicyPaymentsAsync(common);

        public Task<PaidTimeOffPolicyPaymentViewModel> GetInfoPaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoPaidTimeOffPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApprovePaidTimeOffPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApprovePaidTimeOffPolicyPaymentsAsync(common);
    }
}
