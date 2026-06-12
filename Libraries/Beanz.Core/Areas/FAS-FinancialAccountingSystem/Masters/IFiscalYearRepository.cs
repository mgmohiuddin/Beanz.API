using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface IFiscalYearRepository
    {
        Task<List<FiscalYearDTO>> GetFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelFiscalYearsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpFiscalYearsAsync(BeanzCommonDTO lookup);
        Task<FiscalYearViewModel> GetInfoFiscalYearsAsync(BeanzCommonDTO common);
        Task<FiscalYearViewModel> PrintFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveFiscalYearsAsync(BeanzCommonDTO common);
    }
}
