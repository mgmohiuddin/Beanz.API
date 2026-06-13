using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AttendancePolicyPaymentBusiness
    {
        private readonly IAttendancePolicyPaymentRepository _repository;

        public AttendancePolicyPaymentBusiness(IAttendancePolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AttendancePolicyPaymentDTO>> GetAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetAttendancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetAttendancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostAttendancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelAttendancePolicyPaymentsAsync(common);

        public Task<AttendancePolicyPaymentViewModel> GetInfoAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoAttendancePolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveAttendancePolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveAttendancePolicyPaymentsAsync(common);
    }
}
