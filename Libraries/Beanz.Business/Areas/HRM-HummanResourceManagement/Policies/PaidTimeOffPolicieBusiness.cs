using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class PaidTimeOffPolicieBusiness
    {
        private readonly IPaidTimeOffPolicieRepository _repository;

        public PaidTimeOffPolicieBusiness(IPaidTimeOffPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PaidTimeOffPolicieDTO>> GetPaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetPaidTimeOffPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetPaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetPaidTimeOffPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostPaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostPaidTimeOffPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelPaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelPaidTimeOffPoliciesAsync(common);

        public Task<PaidTimeOffPolicieViewModel> GetInfoPaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPaidTimeOffPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApprovePaidTimeOffPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApprovePaidTimeOffPoliciesAsync(common);
    }
}
