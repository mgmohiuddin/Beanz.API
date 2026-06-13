using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IHolidayTypeBusiness
    {
        Task<List<HolidayTypeDTO>> GetHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayTypesAsync(BeanzCommonDTO common);
        Task<HolidayTypeViewModel> GetInfoHolidayTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayTypesAsync(BeanzCommonDTO lookup);
        Task<HolidayTypeViewModel> PrintHolidayTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayTypesAsync(BeanzCommonDTO common);
    }
}
