using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class OverTimePolicieBusiness
    {
        private readonly IOverTimePolicieRepository _repository;

        public OverTimePolicieBusiness(IOverTimePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<OverTimePolicieDTO>> GetOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetOverTimePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetOverTimePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostOverTimePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelOverTimePoliciesAsync(common);

        public Task<OverTimePolicieViewModel> GetInfoOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoOverTimePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveOverTimePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveOverTimePoliciesAsync(common);
    }
}
