using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class GosiPolicyEligibleBusiness
    {
        private readonly IGosiPolicyEligibleRepository _repository;

        public GosiPolicyEligibleBusiness(IGosiPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GosiPolicyEligibleDTO>> GetGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetGosiPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetGosiPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostGosiPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelGosiPolicyEligiblesAsync(common);

        public Task<GosiPolicyEligibleViewModel> GetInfoGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoGosiPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveGosiPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveGosiPolicyEligiblesAsync(common);
    }
}
