using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class TrainingTypeBusiness
    {
        private readonly ITrainingTypeRepository _repository;

        public TrainingTypeBusiness(ITrainingTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TrainingTypeDTO>> GetTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.GetTrainingTypesAsync(common);

        public Task<BeanzResponseDTO> SetTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.SetTrainingTypesAsync(common);

        public Task<BeanzResponseDTO> PostTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.PostTrainingTypesAsync(common);

        public Task<BeanzResponseDTO> DelTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.DelTrainingTypesAsync(common);

        public Task<TrainingTypeViewModel> GetInfoTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTrainingTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveTrainingTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveTrainingTypesAsync(common);
    }
}
