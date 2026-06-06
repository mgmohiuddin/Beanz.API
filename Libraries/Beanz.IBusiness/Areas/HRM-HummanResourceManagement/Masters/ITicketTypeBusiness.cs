using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface ITicketTypeBusiness
    {
        Task<List<TicketTypeDTO>> GetTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketTypesAsync(BeanzCommonDTO common);
        Task<TicketTypeViewModel> GetInfoTicketTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketTypesAsync(BeanzCommonDTO lookup);
        Task<TicketTypeViewModel> PrintTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketTypesAsync(BeanzCommonDTO common);
    }
}
