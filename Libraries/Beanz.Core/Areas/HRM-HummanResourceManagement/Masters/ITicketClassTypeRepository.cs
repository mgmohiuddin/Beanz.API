using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ITicketClassTypeRepository
    {
        Task<List<TicketClassTypeDTO>> GetTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketClassTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketClassTypesAsync(BeanzCommonDTO lookup);
        Task<TicketClassTypeViewModel> GetInfoTicketClassTypesAsync(BeanzCommonDTO common);
        Task<TicketClassTypeViewModel> PrintTicketClassTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketClassTypesAsync(BeanzCommonDTO common);
    }
}
