using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Transactions
{
    public class LeaveOpeningBalanceBusiness
    {
        private readonly ILeaveOpeningBalanceRepository _repository;

        public LeaveOpeningBalanceBusiness(ILeaveOpeningBalanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeaveOpeningBalanceDTO>> GetLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.GetLeaveOpeningBalancesAsync(common);

        public Task<BeanzResponseDTO> SetLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.SetLeaveOpeningBalancesAsync(common);

        public Task<BeanzResponseDTO> PostLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.PostLeaveOpeningBalancesAsync(common);

        public Task<BeanzResponseDTO> DelLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.DelLeaveOpeningBalancesAsync(common);

        public Task<LeaveOpeningBalanceViewModel> GetInfoLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeaveOpeningBalancesAsync(common);

        public Task<BeanzResponseDTO> ApproveLeaveOpeningBalancesAsync(BeanzCommonDTO common)
            => _repository.ApproveLeaveOpeningBalancesAsync(common);
    }
}
