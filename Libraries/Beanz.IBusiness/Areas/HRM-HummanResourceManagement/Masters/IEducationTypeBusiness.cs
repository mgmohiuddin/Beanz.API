using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IEducationTypeBusiness
    {
        Task<List<EducationTypeDTO>> GetEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEducationTypesAsync(BeanzCommonDTO common);
        Task<EducationTypeViewModel> GetInfoEducationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEducationTypesAsync(BeanzCommonDTO lookup);
        Task<EducationTypeViewModel> PrintEducationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEducationTypesAsync(BeanzCommonDTO common);
    }
}
