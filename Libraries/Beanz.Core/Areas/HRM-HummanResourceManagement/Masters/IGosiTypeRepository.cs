using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IGosiTypeRepository
    {
        Task<List<GosiTypeDTO>> GetGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiTypesAsync(BeanzCommonDTO lookup);
        Task<GosiTypeViewModel> GetInfoGosiTypesAsync(BeanzCommonDTO common);
        Task<GosiTypeViewModel> PrintGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiTypesAsync(BeanzCommonDTO common);
    }
}
