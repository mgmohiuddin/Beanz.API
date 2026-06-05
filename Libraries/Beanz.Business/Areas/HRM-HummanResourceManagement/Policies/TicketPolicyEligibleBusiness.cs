using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class TicketPolicyEligibleBusiness
    {
        private readonly ITicketPolicyEligibleRepository _repository;

        public TicketPolicyEligibleBusiness(ITicketPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TicketPolicyEligibleDTO>> GetTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetTicketPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetTicketPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostTicketPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelTicketPolicyEligiblesAsync(common);

        public Task<TicketPolicyEligibleViewModel> GetInfoTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTicketPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveTicketPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveTicketPolicyEligiblesAsync(common);
    }
}
