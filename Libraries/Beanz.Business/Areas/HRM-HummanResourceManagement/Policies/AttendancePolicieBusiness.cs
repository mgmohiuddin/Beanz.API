using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AttendancePolicieBusiness
    {
        private readonly IAttendancePolicieRepository _repository;

        public AttendancePolicieBusiness(IAttendancePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AttendancePolicieDTO>> GetAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetAttendancePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetAttendancePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostAttendancePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelAttendancePoliciesAsync(common);

        public Task<AttendancePolicieViewModel> GetInfoAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAttendancePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveAttendancePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveAttendancePoliciesAsync(common);
    }
}
