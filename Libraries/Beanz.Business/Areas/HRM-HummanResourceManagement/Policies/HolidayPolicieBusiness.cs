using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class HolidayPolicieBusiness
    {
        private readonly IHolidayPolicieRepository _repository;

        public HolidayPolicieBusiness(IHolidayPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HolidayPolicieDTO>> GetHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetHolidayPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetHolidayPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostHolidayPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelHolidayPoliciesAsync(common);

        public Task<HolidayPolicieViewModel> GetInfoHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoHolidayPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveHolidayPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveHolidayPoliciesAsync(common);
    }
}
