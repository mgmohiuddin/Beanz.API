using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HumanResourceManagement.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Transactions
{
    public class LeaveDayBusiness
    {
        private readonly ILeaveDayRepository _repository;

        public LeaveDayBusiness(ILeaveDayRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeaveDayDTO>> GetLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.GetLeaveDaysAsync(common);

        public Task<BeanzResponseDTO> SetLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.SetLeaveDaysAsync(common);

        public Task<BeanzResponseDTO> PostLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.PostLeaveDaysAsync(common);

        public Task<BeanzResponseDTO> DelLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.DelLeaveDaysAsync(common);

        public Task<LeaveDayViewModel> GetInfoLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeaveDaysAsync(common);

        public Task<BeanzResponseDTO> ApproveLeaveDaysAsync(BeanzCommonDTO common)
            => _repository.ApproveLeaveDaysAsync(common);
    }
}
