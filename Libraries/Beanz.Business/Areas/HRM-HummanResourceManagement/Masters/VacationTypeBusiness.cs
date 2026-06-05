using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class VacationTypeBusiness
    {
        private readonly IVacationTypeRepository _repository;

        public VacationTypeBusiness(IVacationTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VacationTypeDTO>> GetVacationTypesAsync(BeanzCommonDTO common)
            => _repository.GetVacationTypesAsync(common);

        public Task<BeanzResponseDTO> SetVacationTypesAsync(BeanzCommonDTO common)
            => _repository.SetVacationTypesAsync(common);

        public Task<BeanzResponseDTO> PostVacationTypesAsync(BeanzCommonDTO common)
            => _repository.PostVacationTypesAsync(common);

        public Task<BeanzResponseDTO> DelVacationTypesAsync(BeanzCommonDTO common)
            => _repository.DelVacationTypesAsync(common);

        public Task<VacationTypeViewModel> GetInfoVacationTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoVacationTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveVacationTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveVacationTypesAsync(common);
    }
}
