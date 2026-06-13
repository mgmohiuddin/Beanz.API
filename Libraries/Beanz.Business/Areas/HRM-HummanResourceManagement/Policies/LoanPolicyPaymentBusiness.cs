using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class LoanPolicyPaymentBusiness
    {
        private readonly ILoanPolicyPaymentRepository _repository;

        public LoanPolicyPaymentBusiness(ILoanPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LoanPolicyPaymentDTO>> GetLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetLoanPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetLoanPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostLoanPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelLoanPolicyPaymentsAsync(common);

        public Task<LoanPolicyPaymentViewModel> GetInfoLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoLoanPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveLoanPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveLoanPolicyPaymentsAsync(common);
    }
}
