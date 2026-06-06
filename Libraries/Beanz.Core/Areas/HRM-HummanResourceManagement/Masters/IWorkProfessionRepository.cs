using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IWorkProfessionRepository
    {
        Task<List<WorkProfessionDTO>> GetWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelWorkProfessionsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpWorkProfessionsAsync(BeanzCommonDTO lookup);
        Task<WorkProfessionViewModel> GetInfoWorkProfessionsAsync(BeanzCommonDTO common);
        Task<WorkProfessionViewModel> PrintWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveWorkProfessionsAsync(BeanzCommonDTO common);
    }
}
