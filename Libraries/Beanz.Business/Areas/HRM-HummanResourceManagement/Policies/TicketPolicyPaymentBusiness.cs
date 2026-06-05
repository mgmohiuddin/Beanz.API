using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class TicketPolicyPaymentBusiness
    {
        private readonly ITicketPolicyPaymentRepository _repository;

        public TicketPolicyPaymentBusiness(ITicketPolicyPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TicketPolicyPaymentDTO>> GetTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetTicketPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> SetTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.SetTicketPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> PostTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.PostTicketPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> DelTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.DelTicketPolicyPaymentsAsync(common);

        public Task<TicketPolicyPaymentViewModel> GetInfoTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoTicketPolicyPaymentsAsync(common);

        public Task<BeanzResponseDTO> ApproveTicketPolicyPaymentsAsync(BeanzCommonDTO common)
            => _repository.ApproveTicketPolicyPaymentsAsync(common);
    }
}
