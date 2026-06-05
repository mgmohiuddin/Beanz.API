using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAllowancePolicyDetailRepository
    {
        Task<List<AllowancePolicyDetailDTO>> GetAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancePolicyDetailsAsync(BeanzCommonDTO lookup);
        Task<AllowancePolicyDetailViewModel> GetInfoAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<AllowancePolicyDetailViewModel> PrintAllowancePolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancePolicyDetailsAsync(BeanzCommonDTO common);
    }
}
