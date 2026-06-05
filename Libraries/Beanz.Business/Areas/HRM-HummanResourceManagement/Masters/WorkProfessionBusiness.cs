using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class WorkProfessionBusiness
    {
        private readonly IWorkProfessionRepository _repository;

        public WorkProfessionBusiness(IWorkProfessionRepository repository)
        {
            _repository = repository;
        }

        public Task<List<WorkProfessionDTO>> GetWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.GetWorkProfessionsAsync(common);

        public Task<BeanzResponseDTO> SetWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.SetWorkProfessionsAsync(common);

        public Task<BeanzResponseDTO> PostWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.PostWorkProfessionsAsync(common);

        public Task<BeanzResponseDTO> DelWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.DelWorkProfessionsAsync(common);

        public Task<WorkProfessionViewModel> GetInfoWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.GetInfoWorkProfessionsAsync(common);

        public Task<BeanzResponseDTO> ApproveWorkProfessionsAsync(BeanzCommonDTO common)
            => _repository.ApproveWorkProfessionsAsync(common);
    }
}
