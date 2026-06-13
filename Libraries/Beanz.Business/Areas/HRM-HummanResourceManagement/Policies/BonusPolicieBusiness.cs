using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class BonusPolicieBusiness
    {
        private readonly IBonusPolicieRepository _repository;

        public BonusPolicieBusiness(IBonusPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BonusPolicieDTO>> GetBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetBonusPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetBonusPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostBonusPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelBonusPoliciesAsync(common);

        public Task<BonusPolicieViewModel> GetInfoBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBonusPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveBonusPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveBonusPoliciesAsync(common);
    }
}
