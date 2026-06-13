using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IVisaTypeBusiness
    {
        Task<List<VisaTypeDTO>> GetVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVisaTypesAsync(BeanzCommonDTO common);
        Task<VisaTypeViewModel> GetInfoVisaTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVisaTypesAsync(BeanzCommonDTO lookup);
        Task<VisaTypeViewModel> PrintVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVisaTypesAsync(BeanzCommonDTO common);
    }
}
