using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
////using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IAllowancePolicyPaymentRepository
    {
        Task<List<AllowancePolicyPaymentDTO>> GetAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpAllowancePolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<AllowancePolicyPaymentViewModel> GetInfoAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<AllowancePolicyPaymentViewModel> PrintAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveAllowancePolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
