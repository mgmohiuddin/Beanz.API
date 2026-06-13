using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IVacationTypeBusiness
    {
        Task<List<VacationTypeDTO>> GetVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVacationTypesAsync(BeanzCommonDTO common);
        Task<VacationTypeViewModel> GetInfoVacationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVacationTypesAsync(BeanzCommonDTO lookup);
        Task<VacationTypeViewModel> PrintVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVacationTypesAsync(BeanzCommonDTO common);
    }
}
