using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class PayrollPolicieBusiness
    {
        private readonly IPayrollPolicieRepository _repository;

        public PayrollPolicieBusiness(IPayrollPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PayrollPolicieDTO>> GetPayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetPayrollPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetPayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetPayrollPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostPayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostPayrollPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelPayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelPayrollPoliciesAsync(common);

        public Task<PayrollPolicieViewModel> GetInfoPayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPayrollPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApprovePayrollPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApprovePayrollPoliciesAsync(common);
    }
}
