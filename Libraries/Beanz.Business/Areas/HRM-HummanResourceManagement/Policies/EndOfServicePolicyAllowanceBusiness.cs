using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class EndOfServicePolicyAllowanceBusiness
    {
        private readonly IEndOfServicePolicyAllowanceRepository _repository;

        public EndOfServicePolicyAllowanceBusiness(IEndOfServicePolicyAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServicePolicyAllowanceDTO>> GetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServicePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServicePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServicePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServicePolicyAllowancesAsync(common);

        public Task<EndOfServicePolicyAllowanceViewModel> GetInfoEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServicePolicyAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServicePolicyAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServicePolicyAllowancesAsync(common);
    }
}
