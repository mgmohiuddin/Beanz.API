using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class GosiPolicieBusiness
    {
        private readonly IGosiPolicieRepository _repository;

        public GosiPolicieBusiness(IGosiPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GosiPolicieDTO>> GetGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetGosiPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetGosiPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostGosiPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelGosiPoliciesAsync(common);

        public Task<GosiPolicieViewModel> GetInfoGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoGosiPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveGosiPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveGosiPoliciesAsync(common);
    }
}
