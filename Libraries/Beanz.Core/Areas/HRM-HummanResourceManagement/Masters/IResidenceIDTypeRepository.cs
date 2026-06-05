using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IResidenceIDTypeRepository
    {
        Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpResidenceIDTypesAsync(BeanzCommonDTO lookup);
        Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<ResidenceIDTypeViewModel> PrintResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveResidenceIDTypesAsync(BeanzCommonDTO common);
    }
}
