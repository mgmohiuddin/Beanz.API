using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface ITicketClassTypeBusiness
    {
        Task<List<TicketClassTypeDTO>> GetTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketClassTypesAsync(BeanzCommonDTO common);
        Task<TicketClassTypeViewModel> GetInfoTicketClassTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketClassTypesAsync(BeanzCommonDTO lookup);
        Task<TicketClassTypeViewModel> PrintTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketClassTypesAsync(BeanzCommonDTO common);
    }
}
