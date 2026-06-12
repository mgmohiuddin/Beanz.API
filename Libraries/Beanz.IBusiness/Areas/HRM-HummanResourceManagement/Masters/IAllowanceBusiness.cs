using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes; 

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface IAllowanceBusiness
    {
        Task<BeanzResponseObjectDTO<List<AllowanceDTO>>> GetAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> SetAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> PostAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> DelAllowancesAsync(BeanzRequestDTO common);
        Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzRequestDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancesAsync(BeanzRequestDTO lookup);
        Task<AllowanceViewModel> PrintAllowancesAsync(BeanzRequestDTO common);
        Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzRequestDTO common);
    }
}
