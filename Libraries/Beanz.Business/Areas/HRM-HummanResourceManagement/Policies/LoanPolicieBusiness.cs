using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class LoanPolicieBusiness
    {
        private readonly ILoanPolicieRepository _repository;

        public LoanPolicieBusiness(ILoanPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LoanPolicieDTO>> GetLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetLoanPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetLoanPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostLoanPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelLoanPoliciesAsync(common);

        public Task<LoanPolicieViewModel> GetInfoLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLoanPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveLoanPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveLoanPoliciesAsync(common);
    }
}
