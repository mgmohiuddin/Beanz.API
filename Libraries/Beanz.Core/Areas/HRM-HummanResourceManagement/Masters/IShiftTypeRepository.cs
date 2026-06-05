using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IShiftTypeRepository
    {
        Task<List<ShiftTypeDTO>> GetShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelShiftTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpShiftTypesAsync(BeanzCommonDTO lookup);
        Task<ShiftTypeViewModel> GetInfoShiftTypesAsync(BeanzCommonDTO common);
        Task<ShiftTypeViewModel> PrintShiftTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveShiftTypesAsync(BeanzCommonDTO common);
    }
}
