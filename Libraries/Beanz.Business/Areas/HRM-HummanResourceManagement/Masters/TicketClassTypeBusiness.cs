using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class TicketClassTypeBusiness
    {
        private readonly ITicketClassTypeRepository _repository;

        public TicketClassTypeBusiness(ITicketClassTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TicketClassTypeDTO>> GetTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.GetTicketClassTypesAsync(common);

        public Task<BeanzResponseDTO> SetTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.SetTicketClassTypesAsync(common);

        public Task<BeanzResponseDTO> PostTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.PostTicketClassTypesAsync(common);

        public Task<BeanzResponseDTO> DelTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.DelTicketClassTypesAsync(common);

        public Task<TicketClassTypeViewModel> GetInfoTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTicketClassTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveTicketClassTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveTicketClassTypesAsync(common);
    }
}
