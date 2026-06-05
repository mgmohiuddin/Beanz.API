using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ISubGradeRepository
    {
        Task<List<SubGradeDTO>> GetSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSubGradesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSubGradesAsync(BeanzCommonDTO lookup);
        Task<SubGradeViewModel> GetInfoSubGradesAsync(BeanzCommonDTO common);
        Task<SubGradeViewModel> PrintSubGradesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSubGradesAsync(BeanzCommonDTO common);
    }
}
