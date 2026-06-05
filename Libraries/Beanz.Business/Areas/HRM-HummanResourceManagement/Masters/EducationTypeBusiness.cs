using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class EducationTypeBusiness
    {
        private readonly IEducationTypeRepository _repository;

        public EducationTypeBusiness(IEducationTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EducationTypeDTO>> GetEducationTypesAsync(BeanzCommonDTO common)
            => _repository.GetEducationTypesAsync(common);

        public Task<BeanzResponseDTO> SetEducationTypesAsync(BeanzCommonDTO common)
            => _repository.SetEducationTypesAsync(common);

        public Task<BeanzResponseDTO> PostEducationTypesAsync(BeanzCommonDTO common)
            => _repository.PostEducationTypesAsync(common);

        public Task<BeanzResponseDTO> DelEducationTypesAsync(BeanzCommonDTO common)
            => _repository.DelEducationTypesAsync(common);

        public Task<EducationTypeViewModel> GetInfoEducationTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEducationTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveEducationTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveEducationTypesAsync(common);
    }
}
