using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IPaidTimeOffTypeBusiness
    {
        Task<List<PaidTimeOffTypeDTO>> GetPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<PaidTimeOffTypeViewModel> GetInfoPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaidTimeOffTypesAsync(BeanzCommonDTO lookup);
        Task<PaidTimeOffTypeViewModel> PrintPaidTimeOffTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaidTimeOffTypesAsync(BeanzCommonDTO common);
    }
}
