using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IHolidayPolicyPaymentRepository
    {
        Task<List<HolidayPolicyPaymentDTO>> GetHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpHolidayPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<HolidayPolicyPaymentViewModel> GetInfoHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<HolidayPolicyPaymentViewModel> PrintHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveHolidayPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
