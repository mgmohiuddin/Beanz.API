using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class GradeBusiness
    {
        private readonly IGradeRepository _repository;

        public GradeBusiness(IGradeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GradeDTO>> GetGradesAsync(BeanzCommonDTO common)
            => _repository.GetGradesAsync(common);

        public Task<BeanzResponseDTO> SetGradesAsync(BeanzCommonDTO common)
            => _repository.SetGradesAsync(common);

        public Task<BeanzResponseDTO> PostGradesAsync(BeanzCommonDTO common)
            => _repository.PostGradesAsync(common);

        public Task<BeanzResponseDTO> DelGradesAsync(BeanzCommonDTO common)
            => _repository.DelGradesAsync(common);

        public Task<GradeViewModel> GetInfoGradesAsync(BeanzCommonDTO common)
            => _repository.GetInfoGradesAsync(common);

        public Task<BeanzResponseDTO> ApproveGradesAsync(BeanzCommonDTO common)
            => _repository.ApproveGradesAsync(common);
    }
}
