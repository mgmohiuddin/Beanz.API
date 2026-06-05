using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class TicketTypeBusiness
    {
        private readonly ITicketTypeRepository _repository;

        public TicketTypeBusiness(ITicketTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TicketTypeDTO>> GetTicketTypesAsync(BeanzCommonDTO common)
            => _repository.GetTicketTypesAsync(common);

        public Task<BeanzResponseDTO> SetTicketTypesAsync(BeanzCommonDTO common)
            => _repository.SetTicketTypesAsync(common);

        public Task<BeanzResponseDTO> PostTicketTypesAsync(BeanzCommonDTO common)
            => _repository.PostTicketTypesAsync(common);

        public Task<BeanzResponseDTO> DelTicketTypesAsync(BeanzCommonDTO common)
            => _repository.DelTicketTypesAsync(common);

        public Task<TicketTypeViewModel> GetInfoTicketTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTicketTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveTicketTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveTicketTypesAsync(common);
    }
}
