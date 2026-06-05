using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class SubGradeBusiness
    {
        private readonly ISubGradeRepository _repository;

        public SubGradeBusiness(ISubGradeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SubGradeDTO>> GetSubGradesAsync(BeanzCommonDTO common)
            => _repository.GetSubGradesAsync(common);

        public Task<BeanzResponseDTO> SetSubGradesAsync(BeanzCommonDTO common)
            => _repository.SetSubGradesAsync(common);

        public Task<BeanzResponseDTO> PostSubGradesAsync(BeanzCommonDTO common)
            => _repository.PostSubGradesAsync(common);

        public Task<BeanzResponseDTO> DelSubGradesAsync(BeanzCommonDTO common)
            => _repository.DelSubGradesAsync(common);

        public Task<SubGradeViewModel> GetInfoSubGradesAsync(BeanzCommonDTO common)
            => _repository.GetInfoSubGradesAsync(common);

        public Task<BeanzResponseDTO> ApproveSubGradesAsync(BeanzCommonDTO common)
            => _repository.ApproveSubGradesAsync(common);
    }
}
