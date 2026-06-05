using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class AdvanceSalaryPolicyPaymentBusiness
    {
        private readonly IAdvanceSalaryPolicyPaymentRepository _repository;

        public AdvanceSalaryPolicyPaymentBusiness(IAdvanceSalaryPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AdvanceSalaryPolicyPaymentDTO>> GetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetAdvanceSalaryPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetAdvanceSalaryPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostAdvanceSalaryPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelAdvanceSalaryPolicyPaymentsAsync(common);

        public Task<AdvanceSalaryPolicyPaymentViewModel> GetInfoAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoAdvanceSalaryPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveAdvanceSalaryPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveAdvanceSalaryPolicyPaymentsAsync(common);
    }
}
