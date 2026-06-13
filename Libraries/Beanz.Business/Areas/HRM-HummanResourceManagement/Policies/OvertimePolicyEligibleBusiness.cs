using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class OvertimePolicyEligibleBusiness
    {
        private readonly IOvertimePolicyEligibleRepository _repository;

        public OvertimePolicyEligibleBusiness(IOvertimePolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<OvertimePolicyEligibleDTO>> GetOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetOvertimePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetOvertimePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostOvertimePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelOvertimePolicyEligiblesAsync(common);

        public Task<OvertimePolicyEligibleViewModel> GetInfoOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoOvertimePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveOvertimePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveOvertimePolicyEligiblesAsync(common);
    }
}
