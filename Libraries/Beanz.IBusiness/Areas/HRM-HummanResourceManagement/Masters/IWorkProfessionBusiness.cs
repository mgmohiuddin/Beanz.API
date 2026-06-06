using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IWorkProfessionBusiness
    {
        Task<List<WorkProfessionDTO>> GetWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelWorkProfessionsAsync(BeanzCommonDTO common);
        Task<WorkProfessionViewModel> GetInfoWorkProfessionsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpWorkProfessionsAsync(BeanzCommonDTO lookup);
        Task<WorkProfessionViewModel> PrintWorkProfessionsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveWorkProfessionsAsync(BeanzCommonDTO common);
    }
}
