using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IOverTimePolicieRepository
    {
        Task<List<OverTimePolicieDTO>> GetOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpOverTimePoliciesAsync(BeanzCommonDTO lookup);
        Task<OverTimePolicieViewModel> GetInfoOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<OverTimePolicieViewModel> PrintOverTimePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveOverTimePoliciesAsync(BeanzCommonDTO common);
    }
}
