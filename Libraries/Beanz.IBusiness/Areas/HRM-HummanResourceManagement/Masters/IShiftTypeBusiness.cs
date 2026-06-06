using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IShiftTypeBusiness
    {
        Task<List<ShiftTypeDTO>> GetShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelShiftTypesAsync(BeanzCommonDTO common);
        Task<ShiftTypeViewModel> GetInfoShiftTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpShiftTypesAsync(BeanzCommonDTO lookup);
        Task<ShiftTypeViewModel> PrintShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveShiftTypesAsync(BeanzCommonDTO common);
    }
}
