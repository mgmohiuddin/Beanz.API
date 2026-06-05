using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AttendanceTypeBusiness
    {
        private readonly IAttendanceTypeRepository _repository;

        public AttendanceTypeBusiness(IAttendanceTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AttendanceTypeDTO>> GetAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.GetAttendanceTypesAsync(common);

        public Task<BeanzResponseDTO> SetAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.SetAttendanceTypesAsync(common);

        public Task<BeanzResponseDTO> PostAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.PostAttendanceTypesAsync(common);

        public Task<BeanzResponseDTO> DelAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.DelAttendanceTypesAsync(common);

        public Task<AttendanceTypeViewModel> GetInfoAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAttendanceTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveAttendanceTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveAttendanceTypesAsync(common);
    }
}
