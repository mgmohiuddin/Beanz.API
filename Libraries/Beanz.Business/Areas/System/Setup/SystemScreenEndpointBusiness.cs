using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Areas.BeanzSystem.Setup;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.BeanzSystem.Setup
{
    public class SystemScreenEndpointBusiness
    {
        private readonly ISystemScreenEndpointRepository _repository;

        public SystemScreenEndpointBusiness(ISystemScreenEndpointRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SystemScreenEndpointDTO>> GetSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.GetSystemScreenEndpointsAsync(common);

        public Task<BeanzResponseDTO> SetSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.SetSystemScreenEndpointsAsync(common);

        public Task<BeanzResponseDTO> PostSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.PostSystemScreenEndpointsAsync(common);

        public Task<BeanzResponseDTO> DelSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.DelSystemScreenEndpointsAsync(common);

        public Task<SystemScreenEndpointViewModel> GetInfoSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.GetInfoSystemScreenEndpointsAsync(common);

        public Task<BeanzResponseDTO> ApproveSystemScreenEndpointsAsync(BeanzCommonDTO common)
            => _repository.ApproveSystemScreenEndpointsAsync(common);
    }
}
