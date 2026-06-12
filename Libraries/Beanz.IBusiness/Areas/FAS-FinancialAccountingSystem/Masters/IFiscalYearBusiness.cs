using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface IFiscalYearBusiness
    {
        Task<List<FiscalYearDTO>> GetFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelFiscalYearsAsync(BeanzCommonDTO common);
        Task<FiscalYearViewModel> GetInfoFiscalYearsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpFiscalYearsAsync(BeanzCommonDTO lookup);
        Task<FiscalYearViewModel> PrintFiscalYearsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveFiscalYearsAsync(BeanzCommonDTO common);
    }
}
