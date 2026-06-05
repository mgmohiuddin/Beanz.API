using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IBonusPolicyPaymentRepository
    {
        Task<List<BonusPolicyPaymentDTO>> GetBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpBonusPolicyPaymentsAsync(BeanzCommonDTO lookup);
        Task<BonusPolicyPaymentViewModel> GetInfoBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BonusPolicyPaymentViewModel> PrintBonusPolicyPaymentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveBonusPolicyPaymentsAsync(BeanzCommonDTO common);
    }
}
