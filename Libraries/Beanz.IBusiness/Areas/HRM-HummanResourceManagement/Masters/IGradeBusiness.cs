using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IGradeBusiness
    {
        Task<List<GradeDTO>> GetGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGradesAsync(BeanzCommonDTO common);
        Task<GradeViewModel> GetInfoGradesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGradesAsync(BeanzCommonDTO lookup);
        Task<GradeViewModel> PrintGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGradesAsync(BeanzCommonDTO common);
    }
}
