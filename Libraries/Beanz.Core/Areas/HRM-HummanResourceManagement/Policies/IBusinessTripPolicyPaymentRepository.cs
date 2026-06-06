using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBusinessTripPolicyPaymentRepository
    {
        Task<List<BusinessTripPolicyPaymentDTO>> GetBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<BusinessTripPolicyPaymentViewModel> GetInfoBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BusinessTripPolicyPaymentViewModel> PrintBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBusinessTripPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
