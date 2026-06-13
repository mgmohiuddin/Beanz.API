using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AllowancePolicyPaymentBusiness
    {
        private readonly IAllowancePolicyPaymentRepository _repository;

        public AllowancePolicyPaymentBusiness(IAllowancePolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowancePolicyPaymentDTO>> GetAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetAllowancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetAllowancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostAllowancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelAllowancePolicyPaymentsAsync(common);

        public Task<AllowancePolicyPaymentViewModel> GetInfoAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancePolicyPaymentsAsync(common);
    }
}
