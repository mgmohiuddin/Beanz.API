using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IPermitTypeBusiness
    {
        Task<List<PermitTypeDTO>> GetPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPermitTypesAsync(BeanzCommonDTO common);
        Task<PermitTypeViewModel> GetInfoPermitTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPermitTypesAsync(BeanzCommonDTO lookup);
        Task<PermitTypeViewModel> PrintPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePermitTypesAsync(BeanzCommonDTO common);
    }
}
