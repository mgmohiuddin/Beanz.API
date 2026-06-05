using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class EndOfServicePolicieBusiness
    {
        private readonly IEndOfServicePolicieRepository _repository;

        public EndOfServicePolicieBusiness(IEndOfServicePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServicePolicieDTO>> GetEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServicePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServicePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServicePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServicePoliciesAsync(common);

        public Task<EndOfServicePolicieViewModel> GetInfoEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServicePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServicePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServicePoliciesAsync(common);
    }
}
