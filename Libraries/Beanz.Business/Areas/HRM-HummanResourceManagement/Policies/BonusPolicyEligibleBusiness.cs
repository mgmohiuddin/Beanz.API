using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class BonusPolicyEligibleBusiness
    {
        private readonly IBonusPolicyEligibleRepository _repository;

        public BonusPolicyEligibleBusiness(IBonusPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BonusPolicyEligibleDTO>> GetBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetBonusPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetBonusPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostBonusPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelBonusPolicyEligiblesAsync(common);

        public Task<BonusPolicyEligibleViewModel> GetInfoBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBonusPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveBonusPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveBonusPolicyEligiblesAsync(common);
    }
}
