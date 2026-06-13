using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IEndOfServiceTypeRepository
    {
        Task<List<EndOfServiceTypeDTO>> GetEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServiceTypesAsync(BeanzCommonDTO lookup);
        Task<EndOfServiceTypeViewModel> GetInfoEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<EndOfServiceTypeViewModel> PrintEndOfServiceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServiceTypesAsync(BeanzCommonDTO common);
    }
}
