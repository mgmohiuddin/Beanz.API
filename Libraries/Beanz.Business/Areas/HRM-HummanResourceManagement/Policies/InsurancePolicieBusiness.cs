using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class InsurancePolicieBusiness
    {
        private readonly IInsurancePolicieRepository _repository;

        public InsurancePolicieBusiness(IInsurancePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<InsurancePolicieDTO>> GetInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInsurancePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetInsurancePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostInsurancePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelInsurancePoliciesAsync(common);

        public Task<InsurancePolicieViewModel> GetInfoInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoInsurancePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveInsurancePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveInsurancePoliciesAsync(common);
    }
}
