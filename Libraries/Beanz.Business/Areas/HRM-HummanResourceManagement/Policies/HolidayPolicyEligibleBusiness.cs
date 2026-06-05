using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class HolidayPolicyEligibleBusiness
    {
        private readonly IHolidayPolicyEligibleRepository _repository;

        public HolidayPolicyEligibleBusiness(IHolidayPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HolidayPolicyEligibleDTO>> GetHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetHolidayPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetHolidayPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostHolidayPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelHolidayPolicyEligiblesAsync(common);

        public Task<HolidayPolicyEligibleViewModel> GetInfoHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoHolidayPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveHolidayPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveHolidayPolicyEligiblesAsync(common);
    }
}
