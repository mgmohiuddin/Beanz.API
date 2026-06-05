using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class PayrollPolicyEligibleBusiness
    {
        private readonly IPayrollPolicyEligibleRepository _repository;

        public PayrollPolicyEligibleBusiness(IPayrollPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PayrollPolicyEligibleDTO>> GetPayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetPayrollPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetPayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetPayrollPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostPayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostPayrollPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelPayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelPayrollPolicyEligiblesAsync(common);

        public Task<PayrollPolicyEligibleViewModel> GetInfoPayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPayrollPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApprovePayrollPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApprovePayrollPolicyEligiblesAsync(common);
    }
}
