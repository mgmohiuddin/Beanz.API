using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class VacationPolicyEligibleBusiness
    {
        private readonly IVacationPolicyEligibleRepository _repository;

        public VacationPolicyEligibleBusiness(IVacationPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VacationPolicyEligibleDTO>> GetVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetVacationPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetVacationPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostVacationPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelVacationPolicyEligiblesAsync(common);

        public Task<VacationPolicyEligibleViewModel> GetInfoVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoVacationPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveVacationPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveVacationPolicyEligiblesAsync(common);
    }
}
