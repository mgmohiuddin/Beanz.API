using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface IEndOfServicePolicyYearSalarieRepository
    {
        Task<List<EndOfServicePolicyYearSalarieDTO>> GetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO lookup);
        Task<EndOfServicePolicyYearSalarieViewModel> GetInfoEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<EndOfServicePolicyYearSalarieViewModel> PrintEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common);
    }
}
