using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IVisaTypeRepository
    {
        Task<List<VisaTypeDTO>> GetVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVisaTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVisaTypesAsync(BeanzCommonDTO lookup);
        Task<VisaTypeViewModel> GetInfoVisaTypesAsync(BeanzCommonDTO common);
        Task<VisaTypeViewModel> PrintVisaTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVisaTypesAsync(BeanzCommonDTO common);
    }
}
