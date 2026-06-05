using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class TicketPolicieBusiness
    {
        private readonly ITicketPolicieRepository _repository;

        public TicketPolicieBusiness(ITicketPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TicketPolicieDTO>> GetTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetTicketPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetTicketPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostTicketPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelTicketPoliciesAsync(common);

        public Task<TicketPolicieViewModel> GetInfoTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTicketPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveTicketPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveTicketPoliciesAsync(common);
    }
}
