using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IResidenceIDTypeBusiness
    {
        Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpResidenceIDTypesAsync(BeanzCommonDTO lookup);
        Task<ResidenceIDTypeViewModel> PrintResidenceIDTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveResidenceIDTypesAsync(BeanzCommonDTO common);
    }
}
