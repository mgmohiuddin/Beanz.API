using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ITicketPolicyEligibleRepository
    {
        Task<List<TicketPolicyEligibleDTO>> GetTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketPolicyEligiblesAsync(BeanzCommonDTO lookup);
        Task<TicketPolicyEligibleViewModel> GetInfoTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<TicketPolicyEligibleViewModel> PrintTicketPolicyEligiblesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketPolicyEligiblesAsync(BeanzCommonDTO common);
    }
}
