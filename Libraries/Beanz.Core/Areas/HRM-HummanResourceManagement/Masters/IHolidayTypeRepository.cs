using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IHolidayTypeRepository
    {
        Task<List<HolidayTypeDTO>> GetHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayTypesAsync(BeanzCommonDTO lookup);
        Task<HolidayTypeViewModel> GetInfoHolidayTypesAsync(BeanzCommonDTO common);
        Task<HolidayTypeViewModel> PrintHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayTypesAsync(BeanzCommonDTO common);
    }
}
