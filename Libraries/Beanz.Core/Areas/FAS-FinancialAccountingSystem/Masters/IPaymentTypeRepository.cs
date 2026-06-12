using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface IPaymentTypeRepository
    {
        Task<List<PaymentTypeDTO>> GetPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaymentTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaymentTypesAsync(BeanzCommonDTO lookup);
        Task<PaymentTypeViewModel> GetInfoPaymentTypesAsync(BeanzCommonDTO common);
        Task<PaymentTypeViewModel> PrintPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaymentTypesAsync(BeanzCommonDTO common);
    }
}
