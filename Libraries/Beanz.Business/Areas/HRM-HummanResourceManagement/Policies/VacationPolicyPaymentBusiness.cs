using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class VacationPolicyPaymentBusiness
    {
        private readonly IVacationPolicyPaymentRepository _repository;

        public VacationPolicyPaymentBusiness(IVacationPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VacationPolicyPaymentDTO>> GetVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetVacationPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetVacationPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostVacationPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelVacationPolicyPaymentsAsync(common);

        public Task<VacationPolicyPaymentViewModel> GetInfoVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoVacationPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveVacationPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveVacationPolicyPaymentsAsync(common);
    }
}
