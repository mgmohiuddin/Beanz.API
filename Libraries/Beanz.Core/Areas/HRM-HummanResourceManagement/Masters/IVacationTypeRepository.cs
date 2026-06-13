using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IVacationTypeRepository
    {
        Task<List<VacationTypeDTO>> GetVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVacationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVacationTypesAsync(BeanzCommonDTO lookup);
        Task<VacationTypeViewModel> GetInfoVacationTypesAsync(BeanzCommonDTO common);
        Task<VacationTypeViewModel> PrintVacationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVacationTypesAsync(BeanzCommonDTO common);
    }
}
