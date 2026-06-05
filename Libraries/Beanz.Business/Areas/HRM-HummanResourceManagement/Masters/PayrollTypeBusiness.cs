using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class PayrollTypeBusiness
    {
        private readonly IPayrollTypeRepository _repository;

        public PayrollTypeBusiness(IPayrollTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PayrollTypeDTO>> GetPayrollTypesAsync(BeanzCommonDTO common)
            => _repository.GetPayrollTypesAsync(common);

        public Task<BeanzResponseDTO> SetPayrollTypesAsync(BeanzCommonDTO common)
            => _repository.SetPayrollTypesAsync(common);

        public Task<BeanzResponseDTO> PostPayrollTypesAsync(BeanzCommonDTO common)
            => _repository.PostPayrollTypesAsync(common);

        public Task<BeanzResponseDTO> DelPayrollTypesAsync(BeanzCommonDTO common)
            => _repository.DelPayrollTypesAsync(common);

        public Task<PayrollTypeViewModel> GetInfoPayrollTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPayrollTypesAsync(common);

        public Task<BeanzResponseDTO> ApprovePayrollTypesAsync(BeanzCommonDTO common)
            => _repository.ApprovePayrollTypesAsync(common);
    }
}
