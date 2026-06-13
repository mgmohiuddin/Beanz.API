using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface ISubGradeBusiness
    {
        Task<List<SubGradeDTO>> GetSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSubGradesAsync(BeanzCommonDTO common);
        Task<SubGradeViewModel> GetInfoSubGradesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSubGradesAsync(BeanzCommonDTO lookup);
        Task<SubGradeViewModel> PrintSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSubGradesAsync(BeanzCommonDTO common);
    }
}
