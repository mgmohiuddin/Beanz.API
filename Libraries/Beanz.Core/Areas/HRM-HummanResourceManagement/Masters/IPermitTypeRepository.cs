using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IPermitTypeRepository
    {
        Task<List<PermitTypeDTO>> GetPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPermitTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPermitTypesAsync(BeanzCommonDTO lookup);
        Task<PermitTypeViewModel> GetInfoPermitTypesAsync(BeanzCommonDTO common);
        Task<PermitTypeViewModel> PrintPermitTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePermitTypesAsync(BeanzCommonDTO common);
    }
}
