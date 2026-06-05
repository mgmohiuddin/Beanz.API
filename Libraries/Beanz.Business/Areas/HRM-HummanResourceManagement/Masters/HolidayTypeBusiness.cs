using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class HolidayTypeBusiness
    {
        private readonly IHolidayTypeRepository _repository;

        public HolidayTypeBusiness(IHolidayTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HolidayTypeDTO>> GetHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.GetHolidayTypesAsync(common);

        public Task<BeanzResponseDTO> SetHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.SetHolidayTypesAsync(common);

        public Task<BeanzResponseDTO> PostHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.PostHolidayTypesAsync(common);

        public Task<BeanzResponseDTO> DelHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.DelHolidayTypesAsync(common);

        public Task<HolidayTypeViewModel> GetInfoHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoHolidayTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveHolidayTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveHolidayTypesAsync(common);
    }
}
