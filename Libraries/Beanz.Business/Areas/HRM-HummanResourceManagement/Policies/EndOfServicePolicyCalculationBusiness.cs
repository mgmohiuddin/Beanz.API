using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class EndOfServicePolicyCalculationBusiness
    {
        private readonly IEndOfServicePolicyCalculationRepository _repository;

        public EndOfServicePolicyCalculationBusiness(IEndOfServicePolicyCalculationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServicePolicyCalculationDTO>> GetEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServicePolicyCalculationsAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServicePolicyCalculationsAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServicePolicyCalculationsAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServicePolicyCalculationsAsync(common);

        public Task<EndOfServicePolicyCalculationViewModel> GetInfoEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServicePolicyCalculationsAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServicePolicyCalculationsAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServicePolicyCalculationsAsync(common);
    }
}
