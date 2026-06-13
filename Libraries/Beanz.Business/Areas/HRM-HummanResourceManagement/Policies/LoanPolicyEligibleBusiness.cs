using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class LoanPolicyEligibleBusiness
    {
        private readonly ILoanPolicyEligibleRepository _repository;

        public LoanPolicyEligibleBusiness(ILoanPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LoanPolicyEligibleDTO>> GetLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetLoanPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetLoanPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostLoanPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelLoanPolicyEligiblesAsync(common);

        public Task<LoanPolicyEligibleViewModel> GetInfoLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLoanPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveLoanPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveLoanPolicyEligiblesAsync(common);
    }
}
