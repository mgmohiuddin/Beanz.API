using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class LeavePolicyPaymentBusiness
    {
        private readonly ILeavePolicyPaymentRepository _repository;

        public LeavePolicyPaymentBusiness(ILeavePolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeavePolicyPaymentDTO>> GetLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetLeavePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetLeavePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostLeavePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelLeavePolicyPaymentsAsync(common);

        public Task<LeavePolicyPaymentViewModel> GetInfoLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeavePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveLeavePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveLeavePolicyPaymentsAsync(common);
    }
}
