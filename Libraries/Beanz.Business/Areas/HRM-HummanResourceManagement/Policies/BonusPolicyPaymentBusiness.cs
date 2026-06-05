using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class BonusPolicyPaymentBusiness
    {
        private readonly IBonusPolicyPaymentRepository _repository;

        public BonusPolicyPaymentBusiness(IBonusPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BonusPolicyPaymentDTO>> GetBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetBonusPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetBonusPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostBonusPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelBonusPolicyPaymentsAsync(common);

        public Task<BonusPolicyPaymentViewModel> GetInfoBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoBonusPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveBonusPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveBonusPolicyPaymentsAsync(common);
    }
}
