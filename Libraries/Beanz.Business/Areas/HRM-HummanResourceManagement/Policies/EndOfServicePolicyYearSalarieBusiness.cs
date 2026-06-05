using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class EndOfServicePolicyYearSalarieBusiness
    {
        private readonly IEndOfServicePolicyYearSalarieRepository _repository;

        public EndOfServicePolicyYearSalarieBusiness(IEndOfServicePolicyYearSalarieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServicePolicyYearSalarieDTO>> GetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServicePolicyYearSalariesAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServicePolicyYearSalariesAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServicePolicyYearSalariesAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServicePolicyYearSalariesAsync(common);

        public Task<EndOfServicePolicyYearSalarieViewModel> GetInfoEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServicePolicyYearSalariesAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServicePolicyYearSalariesAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServicePolicyYearSalariesAsync(common);
    }
}
