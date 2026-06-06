using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ITicketPolicieRepository
    {
        Task<List<TicketPolicieDTO>> GetTicketPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketPoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketPoliciesAsync(BeanzCommonDTO lookup);
        Task<TicketPolicieViewModel> GetInfoTicketPoliciesAsync(BeanzCommonDTO common);
        Task<TicketPolicieViewModel> PrintTicketPoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketPoliciesAsync(BeanzCommonDTO common);
    }
}
