using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AdvanceSalaryPolicieBusiness
    {
        private readonly IAdvanceSalaryPolicieRepository _repository;

        public AdvanceSalaryPolicieBusiness(IAdvanceSalaryPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AdvanceSalaryPolicieDTO>> GetAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetAdvanceSalaryPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetAdvanceSalaryPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostAdvanceSalaryPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelAdvanceSalaryPoliciesAsync(common);

        public Task<AdvanceSalaryPolicieViewModel> GetInfoAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAdvanceSalaryPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveAdvanceSalaryPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveAdvanceSalaryPoliciesAsync(common);
    }
}
