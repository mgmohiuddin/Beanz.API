using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class LeaveTypeBusiness
    {
        private readonly ILeaveTypeRepository _repository;

        public LeaveTypeBusiness(ILeaveTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeaveTypeDTO>> GetLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.GetLeaveTypesAsync(common);

        public Task<BeanzResponseDTO> SetLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.SetLeaveTypesAsync(common);

        public Task<BeanzResponseDTO> PostLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.PostLeaveTypesAsync(common);

        public Task<BeanzResponseDTO> DelLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.DelLeaveTypesAsync(common);

        public Task<LeaveTypeViewModel> GetInfoLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeaveTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveLeaveTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveLeaveTypesAsync(common);
    }
}
