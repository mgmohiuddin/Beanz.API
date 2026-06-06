using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ITrainingPolicieRepository
    {
        Task<List<TrainingPolicieDTO>> GetTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTrainingPoliciesAsync(BeanzCommonDTO lookup);
        Task<TrainingPolicieViewModel> GetInfoTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<TrainingPolicieViewModel> PrintTrainingPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTrainingPoliciesAsync(BeanzCommonDTO common);
    }
}
