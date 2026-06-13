using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Transactions
{
    public class LeaveBusiness
    {
        private readonly ILeaveRepository _repository;

        public LeaveBusiness(ILeaveRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeaveDTO>> GetLeavesAsync(BeanzCommonDTO common)
            => _repository.GetLeavesAsync(common);

        public Task<BeanzResponseDTO> SetLeavesAsync(BeanzCommonDTO common)
            => _repository.SetLeavesAsync(common);

        public Task<BeanzResponseDTO> PostLeavesAsync(BeanzCommonDTO common)
            => _repository.PostLeavesAsync(common);

        public Task<BeanzResponseDTO> DelLeavesAsync(BeanzCommonDTO common)
            => _repository.DelLeavesAsync(common);

        public Task<LeaveViewModel> GetInfoLeavesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeavesAsync(common);

        public Task<BeanzResponseDTO> ApproveLeavesAsync(BeanzCommonDTO common)
            => _repository.ApproveLeavesAsync(common);
    }
}
