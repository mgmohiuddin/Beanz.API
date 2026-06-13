using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Transactions
{
    public interface IPayrollPeriodRepository
    {
        Task<List<PayrollPeriodDTO>> GetPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollPeriodsAsync(BeanzCommonDTO lookup);
        Task<PayrollPeriodViewModel> GetInfoPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<PayrollPeriodViewModel> PrintPayrollPeriodsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollPeriodsAsync(BeanzCommonDTO common);
    }
}
