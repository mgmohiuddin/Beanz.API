using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IPaidTimeOffTypeRepository
    {
        Task<List<PaidTimeOffTypeDTO>> GetPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaidTimeOffTypesAsync(BeanzCommonDTO lookup);
        Task<PaidTimeOffTypeViewModel> GetInfoPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<PaidTimeOffTypeViewModel> PrintPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaidTimeOffTypesAsync(BeanzCommonDTO common);
    }
}
