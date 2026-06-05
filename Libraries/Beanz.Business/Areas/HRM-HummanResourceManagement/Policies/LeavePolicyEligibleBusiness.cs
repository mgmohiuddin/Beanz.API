using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class LeavePolicyEligibleBusiness
    {
        private readonly ILeavePolicyEligibleRepository _repository;

        public LeavePolicyEligibleBusiness(ILeavePolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeavePolicyEligibleDTO>> GetLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetLeavePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetLeavePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostLeavePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelLeavePolicyEligiblesAsync(common);

        public Task<LeavePolicyEligibleViewModel> GetInfoLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeavePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveLeavePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveLeavePolicyEligiblesAsync(common);
    }
}
