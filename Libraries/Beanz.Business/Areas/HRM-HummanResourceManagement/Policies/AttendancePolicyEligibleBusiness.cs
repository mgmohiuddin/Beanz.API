using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class AttendancePolicyEligibleBusiness
    {
        private readonly IAttendancePolicyEligibleRepository _repository;

        public AttendancePolicyEligibleBusiness(IAttendancePolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AttendancePolicyEligibleDTO>> GetAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetAttendancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetAttendancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostAttendancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelAttendancePolicyEligiblesAsync(common);

        public Task<AttendancePolicyEligibleViewModel> GetInfoAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAttendancePolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveAttendancePolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveAttendancePolicyEligiblesAsync(common);
    }
}
