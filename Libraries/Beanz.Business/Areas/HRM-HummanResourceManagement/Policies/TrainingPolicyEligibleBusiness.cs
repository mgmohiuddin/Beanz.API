using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class TrainingPolicyEligibleBusiness
    {
        private readonly ITrainingPolicyEligibleRepository _repository;

        public TrainingPolicyEligibleBusiness(ITrainingPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TrainingPolicyEligibleDTO>> GetTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetTrainingPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetTrainingPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostTrainingPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelTrainingPolicyEligiblesAsync(common);

        public Task<TrainingPolicyEligibleViewModel> GetInfoTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTrainingPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveTrainingPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveTrainingPolicyEligiblesAsync(common);
    }
}
