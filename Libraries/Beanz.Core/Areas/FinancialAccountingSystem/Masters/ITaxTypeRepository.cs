using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface ITaxTypeRepository
    {
        Task<List<TaxTypeDTO>> GetTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelTaxTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpTaxTypesAsync(BeanzCommonDTO lookup);
        Task<TaxTypeViewModel> GetInfoTaxTypesAsync(BeanzCommonDTO common);
        Task<TaxTypeViewModel> PrintTaxTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveTaxTypesAsync(BeanzCommonDTO common);
    }
}
