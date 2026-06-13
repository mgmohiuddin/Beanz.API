using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class HolidayPolicyPaymentBusiness
    {
        private readonly IHolidayPolicyPaymentRepository _repository;

        public HolidayPolicyPaymentBusiness(IHolidayPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<HolidayPolicyPaymentDTO>> GetHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetHolidayPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetHolidayPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostHolidayPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelHolidayPolicyPaymentsAsync(common);

        public Task<HolidayPolicyPaymentViewModel> GetInfoHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoHolidayPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveHolidayPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveHolidayPolicyPaymentsAsync(common);
    }
}
