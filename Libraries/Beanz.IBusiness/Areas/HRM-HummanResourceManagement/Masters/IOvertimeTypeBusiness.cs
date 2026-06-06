using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IOvertimeTypeBusiness
    {
        Task<List<OvertimeTypeDTO>> GetOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOvertimeTypesAsync(BeanzCommonDTO common);
        Task<OvertimeTypeViewModel> GetInfoOvertimeTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOvertimeTypesAsync(BeanzCommonDTO lookup);
        Task<OvertimeTypeViewModel> PrintOvertimeTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOvertimeTypesAsync(BeanzCommonDTO common);
    }
}
