using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class PayrollPolicyPaymentBusiness
    {
        private readonly IPayrollPolicyPaymentRepository _repository;

        public PayrollPolicyPaymentBusiness(IPayrollPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PayrollPolicyPaymentDTO>> GetPayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetPayrollPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetPayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetPayrollPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostPayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostPayrollPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelPayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelPayrollPolicyPaymentsAsync(common);

        public Task<PayrollPolicyPaymentViewModel> GetInfoPayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoPayrollPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApprovePayrollPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApprovePayrollPolicyPaymentsAsync(common);
    }
}
