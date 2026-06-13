using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AllowancePolicieBusiness
    {
        private readonly IAllowancePolicieRepository _repository;

        public AllowancePolicieBusiness(IAllowancePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowancePolicieDTO>> GetAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetAllowancePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetAllowancePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostAllowancePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelAllowancePoliciesAsync(common);

        public Task<AllowancePolicieViewModel> GetInfoAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancePoliciesAsync(common);
    }
}
