using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class InsurancePolicyEligibleBusiness
    {
        private readonly IInsurancePolicyEligibleRepository _repository;

        public InsurancePolicyEligibleBusiness(IInsurancePolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<InsurancePolicyEligibleDTO>> GetInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInsurancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetInsurancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostInsurancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelInsurancePolicyEligiblesAsync(common);

        public Task<InsurancePolicyEligibleViewModel> GetInfoInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoInsurancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveInsurancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveInsurancePolicyEligiblesAsync(common);
    }
}
