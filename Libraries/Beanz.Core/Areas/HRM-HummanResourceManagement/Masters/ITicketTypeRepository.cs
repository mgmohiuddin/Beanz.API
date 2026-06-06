using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ITicketTypeRepository
    {
        Task<List<TicketTypeDTO>> GetTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketTypesAsync(BeanzCommonDTO lookup);
        Task<TicketTypeViewModel> GetInfoTicketTypesAsync(BeanzCommonDTO common);
        Task<TicketTypeViewModel> PrintTicketTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketTypesAsync(BeanzCommonDTO common);
    }
}
