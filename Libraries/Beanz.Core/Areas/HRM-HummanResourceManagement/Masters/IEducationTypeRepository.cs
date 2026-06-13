using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IEducationTypeRepository
    {
        Task<List<EducationTypeDTO>> GetEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEducationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEducationTypesAsync(BeanzCommonDTO lookup);
        Task<EducationTypeViewModel> GetInfoEducationTypesAsync(BeanzCommonDTO common);
        Task<EducationTypeViewModel> PrintEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEducationTypesAsync(BeanzCommonDTO common);
    }
}
