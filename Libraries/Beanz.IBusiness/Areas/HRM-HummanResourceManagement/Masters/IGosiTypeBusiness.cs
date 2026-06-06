using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IGosiTypeBusiness
    {
        Task<List<GosiTypeDTO>> GetGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiTypesAsync(BeanzCommonDTO common);
        Task<GosiTypeViewModel> GetInfoGosiTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiTypesAsync(BeanzCommonDTO lookup);
        Task<GosiTypeViewModel> PrintGosiTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiTypesAsync(BeanzCommonDTO common);
    }
}
