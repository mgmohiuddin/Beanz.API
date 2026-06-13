using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IAllowancesGroupBusiness
    {
        Task<List<AllowancesGroupDTO>> GetAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<AllowancesGroupViewModel> GetInfoAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancesGroupsAsync(BeanzCommonDTO lookup);
        Task<AllowancesGroupViewModel> PrintAllowancesGroupsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesGroupsAsync(BeanzCommonDTO common);
    }
}
