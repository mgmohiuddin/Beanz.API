using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Transactions
{
    public class PayrollPeriodBusiness
    {
        private readonly IPayrollPeriodRepository _repository;

        public PayrollPeriodBusiness(IPayrollPeriodRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PayrollPeriodDTO>> GetPayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.GetPayrollPeriodsAsync(common);

        public Task<BeanzResponseDTO> SetPayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.SetPayrollPeriodsAsync(common);

        public Task<BeanzResponseDTO> PostPayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.PostPayrollPeriodsAsync(common);

        public Task<BeanzResponseDTO> DelPayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.DelPayrollPeriodsAsync(common);

        public Task<PayrollPeriodViewModel> GetInfoPayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.GetInfoPayrollPeriodsAsync(common);

        public Task<BeanzResponseDTO> ApprovePayrollPeriodsAsync(BeanzCommonDTO common)
            => _repository.ApprovePayrollPeriodsAsync(common);
    }
}
