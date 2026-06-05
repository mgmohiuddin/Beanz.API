using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class PositionBusiness
    {
        private readonly IPositionRepository _repository;

        public PositionBusiness(IPositionRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PositionDTO>> GetPositionsAsync(BeanzCommonDTO common)
            => _repository.GetPositionsAsync(common);

        public Task<BeanzResponseDTO> SetPositionsAsync(BeanzCommonDTO common)
            => _repository.SetPositionsAsync(common);

        public Task<BeanzResponseDTO> PostPositionsAsync(BeanzCommonDTO common)
            => _repository.PostPositionsAsync(common);

        public Task<BeanzResponseDTO> DelPositionsAsync(BeanzCommonDTO common)
            => _repository.DelPositionsAsync(common);

        public Task<PositionViewModel> GetInfoPositionsAsync(BeanzCommonDTO common)
            => _repository.GetInfoPositionsAsync(common);

        public Task<BeanzResponseDTO> ApprovePositionsAsync(BeanzCommonDTO common)
            => _repository.ApprovePositionsAsync(common);
    }
}
