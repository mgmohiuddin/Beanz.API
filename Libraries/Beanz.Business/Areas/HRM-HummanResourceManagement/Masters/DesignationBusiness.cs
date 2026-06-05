using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class DesignationBusiness
    {
        private readonly IDesignationRepository _repository;

        public DesignationBusiness(IDesignationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<DesignationDTO>> GetDesignationsAsync(BeanzCommonDTO common)
            => _repository.GetDesignationsAsync(common);

        public Task<BeanzResponseDTO> SetDesignationsAsync(BeanzCommonDTO common)
            => _repository.SetDesignationsAsync(common);

        public Task<BeanzResponseDTO> PostDesignationsAsync(BeanzCommonDTO common)
            => _repository.PostDesignationsAsync(common);

        public Task<BeanzResponseDTO> DelDesignationsAsync(BeanzCommonDTO common)
            => _repository.DelDesignationsAsync(common);

        public Task<DesignationViewModel> GetInfoDesignationsAsync(BeanzCommonDTO common)
            => _repository.GetInfoDesignationsAsync(common);

        public Task<BeanzResponseDTO> ApproveDesignationsAsync(BeanzCommonDTO common)
            => _repository.ApproveDesignationsAsync(common);
    }
}
