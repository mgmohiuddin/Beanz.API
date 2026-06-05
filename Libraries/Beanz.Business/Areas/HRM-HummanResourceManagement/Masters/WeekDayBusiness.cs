using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class WeekDayBusiness
    {
        private readonly IWeekDayRepository _repository;

        public WeekDayBusiness(IWeekDayRepository repository)
        {
            _repository = repository;
        }

        public Task<List<WeekDayDTO>> GetWeekDaysAsync(BeanzCommonDTO common)
            => _repository.GetWeekDaysAsync(common);

        public Task<BeanzResponseDTO> SetWeekDaysAsync(BeanzCommonDTO common)
            => _repository.SetWeekDaysAsync(common);

        public Task<BeanzResponseDTO> PostWeekDaysAsync(BeanzCommonDTO common)
            => _repository.PostWeekDaysAsync(common);

        public Task<BeanzResponseDTO> DelWeekDaysAsync(BeanzCommonDTO common)
            => _repository.DelWeekDaysAsync(common);

        public Task<WeekDayViewModel> GetInfoWeekDaysAsync(BeanzCommonDTO common)
            => _repository.GetInfoWeekDaysAsync(common);

        public Task<BeanzResponseDTO> ApproveWeekDaysAsync(BeanzCommonDTO common)
            => _repository.ApproveWeekDaysAsync(common);
    }
}
