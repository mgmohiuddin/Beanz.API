using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class OverTimePolicyAllowanceBusiness
    {
        private readonly IOverTimePolicyAllowanceRepository _repository;

        public OverTimePolicyAllowanceBusiness(IOverTimePolicyAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<OverTimePolicyAllowanceDTO>> GetOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetOverTimePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetOverTimePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostOverTimePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelOverTimePolicyAllowancesAsync(common);

        public Task<OverTimePolicyAllowanceViewModel> GetInfoOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoOverTimePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveOverTimePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveOverTimePolicyAllowancesAsync(common);
    }
}
