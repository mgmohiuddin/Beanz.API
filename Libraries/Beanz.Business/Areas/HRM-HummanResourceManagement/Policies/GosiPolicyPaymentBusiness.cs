using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class GosiPolicyPaymentBusiness
    {
        private readonly IGosiPolicyPaymentRepository _repository;

        public GosiPolicyPaymentBusiness(IGosiPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GosiPolicyPaymentDTO>> GetGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetGosiPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetGosiPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostGosiPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelGosiPolicyPaymentsAsync(common);

        public Task<GosiPolicyPaymentViewModel> GetInfoGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoGosiPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveGosiPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveGosiPolicyPaymentsAsync(common);
    }
}
