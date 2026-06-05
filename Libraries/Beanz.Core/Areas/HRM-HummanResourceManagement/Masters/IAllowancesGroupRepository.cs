using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IAllowancesGroupRepository
    {
        Task<List<AllowancesGroupDTO>> GetAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancesGroupsAsync(BeanzCommonDTO lookup);
        Task<AllowancesGroupViewModel> GetInfoAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<AllowancesGroupViewModel> PrintAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesGroupsAsync(BeanzCommonDTO common);
    }
}
