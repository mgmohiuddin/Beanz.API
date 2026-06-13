using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class HolidayPolicyDayBusiness
    {
        private readonly IHolidayPolicyDayRepository _repository;

        public HolidayPolicyDayBusiness(IHolidayPolicyDayRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HolidayPolicyDayDTO>> GetHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.GetHolidayPolicyDaysAsync(common);

        public Task<BeanzResponseDTO> SetHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.SetHolidayPolicyDaysAsync(common);

        public Task<BeanzResponseDTO> PostHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.PostHolidayPolicyDaysAsync(common);

        public Task<BeanzResponseDTO> DelHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.DelHolidayPolicyDaysAsync(common);

        public Task<HolidayPolicyDayViewModel> GetInfoHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.GetInfoHolidayPolicyDaysAsync(common);

        public Task<BeanzResponseDTO> ApproveHolidayPolicyDaysAsync(BeanzCommonDTO common)
            => _repository.ApproveHolidayPolicyDaysAsync(common);
    }
}
