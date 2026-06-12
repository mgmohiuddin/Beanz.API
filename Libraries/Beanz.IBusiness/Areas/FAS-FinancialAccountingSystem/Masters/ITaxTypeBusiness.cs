using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface ITaxTypeBusiness
    {
        Task<List<TaxTypeDTO>> GetTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTaxTypesAsync(BeanzCommonDTO common);
        Task<TaxTypeViewModel> GetInfoTaxTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTaxTypesAsync(BeanzCommonDTO lookup);
        Task<TaxTypeViewModel> PrintTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTaxTypesAsync(BeanzCommonDTO common);
    }
}
