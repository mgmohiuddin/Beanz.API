using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface ITicketPolicyPaymentRepository
    {
        Task<List<TicketPolicyPaymentDTO>> GetTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTicketPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<TicketPolicyPaymentViewModel> GetInfoTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<TicketPolicyPaymentViewModel> PrintTicketPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTicketPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
