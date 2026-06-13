using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IGradeRepository
    {
        Task<List<GradeDTO>> GetGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGradesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGradesAsync(BeanzCommonDTO lookup);
        Task<GradeViewModel> GetInfoGradesAsync(BeanzCommonDTO common);
        Task<GradeViewModel> PrintGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGradesAsync(BeanzCommonDTO common);
    }
}
