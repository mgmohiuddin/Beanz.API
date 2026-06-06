using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IGosiPolicyPaymentRepository
    {
        Task<List<GosiPolicyPaymentDTO>> GetGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpGosiPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<GosiPolicyPaymentViewModel> GetInfoGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<GosiPolicyPaymentViewModel> PrintGosiPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveGosiPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
