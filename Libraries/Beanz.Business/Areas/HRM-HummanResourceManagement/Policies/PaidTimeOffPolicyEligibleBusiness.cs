using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class PaidTimeOffPolicyEligibleBusiness
    {
        private readonly IPaidTimeOffPolicyEligibleRepository _repository;

        public PaidTimeOffPolicyEligibleBusiness(IPaidTimeOffPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PaidTimeOffPolicyEligibleDTO>> GetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetPaidTimeOffPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetPaidTimeOffPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostPaidTimeOffPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelPaidTimeOffPolicyEligiblesAsync(common);

        public Task<PaidTimeOffPolicyEligibleViewModel> GetInfoPaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPaidTimeOffPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApprovePaidTimeOffPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApprovePaidTimeOffPolicyEligiblesAsync(common);
    }
}
