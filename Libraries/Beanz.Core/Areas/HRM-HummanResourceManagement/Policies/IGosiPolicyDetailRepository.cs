using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IGosiPolicyDetailRepository
    {
        Task<List<GosiPolicyDetailDTO>> GetGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiPolicyDetailsAsync(BeanzCommonDTO lookup);
        Task<GosiPolicyDetailViewModel> GetInfoGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<GosiPolicyDetailViewModel> PrintGosiPolicyDetailsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiPolicyDetailsAsync(BeanzCommonDTO common);
    }
}
