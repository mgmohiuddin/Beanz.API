using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class TrainingPolicieBusiness
    {
        private readonly ITrainingPolicieRepository _repository;

        public TrainingPolicieBusiness(ITrainingPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TrainingPolicieDTO>> GetTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetTrainingPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetTrainingPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostTrainingPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelTrainingPoliciesAsync(common);

        public Task<TrainingPolicieViewModel> GetInfoTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTrainingPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveTrainingPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveTrainingPoliciesAsync(common);
    }
}
