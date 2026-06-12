using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface IPaymentTypeBusiness
    {
        Task<List<PaymentTypeDTO>> GetPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPaymentTypesAsync(BeanzCommonDTO common);
        Task<PaymentTypeViewModel> GetInfoPaymentTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPaymentTypesAsync(BeanzCommonDTO lookup);
        Task<PaymentTypeViewModel> PrintPaymentTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePaymentTypesAsync(BeanzCommonDTO common);
    }
}
