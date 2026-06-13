using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface ITrainingTypeBusiness
    {
        Task<List<TrainingTypeDTO>> GetTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTrainingTypesAsync(BeanzCommonDTO common);
        Task<TrainingTypeViewModel> GetInfoTrainingTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTrainingTypesAsync(BeanzCommonDTO lookup);
        Task<TrainingTypeViewModel> PrintTrainingTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTrainingTypesAsync(BeanzCommonDTO common);
    }
}
