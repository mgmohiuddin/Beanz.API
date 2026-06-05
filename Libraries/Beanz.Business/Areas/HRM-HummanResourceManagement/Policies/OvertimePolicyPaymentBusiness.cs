using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class OvertimePolicyPaymentBusiness
    {
        private readonly IOvertimePolicyPaymentRepository _repository;

        public OvertimePolicyPaymentBusiness(IOvertimePolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<OvertimePolicyPaymentDTO>> GetOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetOvertimePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetOvertimePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostOvertimePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelOvertimePolicyPaymentsAsync(common);

        public Task<OvertimePolicyPaymentViewModel> GetInfoOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoOvertimePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveOvertimePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveOvertimePolicyPaymentsAsync(common);
    }
}
