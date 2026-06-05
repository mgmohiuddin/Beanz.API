using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceBusiness
    {
        Task<List<AllowanceDTO>> GetAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancesAsync(BeanzCommonDTO common);
        Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzCommonDTO common);
    }
}
