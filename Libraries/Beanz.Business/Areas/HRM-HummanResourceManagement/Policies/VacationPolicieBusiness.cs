using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class VacationPolicieBusiness
    {
        private readonly IVacationPolicieRepository _repository;

        public VacationPolicieBusiness(IVacationPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VacationPolicieDTO>> GetVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetVacationPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetVacationPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostVacationPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelVacationPoliciesAsync(common);

        public Task<VacationPolicieViewModel> GetInfoVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoVacationPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveVacationPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveVacationPoliciesAsync(common);
    }
}
