using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface ITrainingTypeRepository
    {
        Task<List<TrainingTypeDTO>> GetTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTrainingTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTrainingTypesAsync(BeanzCommonDTO lookup);
        Task<TrainingTypeViewModel> GetInfoTrainingTypesAsync(BeanzCommonDTO common);
        Task<TrainingTypeViewModel> PrintTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTrainingTypesAsync(BeanzCommonDTO common);
    }
}
