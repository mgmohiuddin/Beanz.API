using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Policies
{
    public interface ITrainingPolicyEligibleRepository
    {
        Task<List<TrainingPolicyEligibleDTO>> GetTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTrainingPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<TrainingPolicyEligibleViewModel> GetInfoTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<TrainingPolicyEligibleViewModel> PrintTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTrainingPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
