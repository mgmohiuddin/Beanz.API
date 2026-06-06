using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IEndOfServiceTypeBusiness
    {
        Task<List<EndOfServiceTypeDTO>> GetEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<EndOfServiceTypeViewModel> GetInfoEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServiceTypesAsync(BeanzCommonDTO lookup);
        Task<EndOfServiceTypeViewModel> PrintEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServiceTypesAsync(BeanzCommonDTO common);
    }
}
