using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class VisaTypeBusiness
    {
        private readonly IVisaTypeRepository _repository;

        public VisaTypeBusiness(IVisaTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VisaTypeDTO>> GetVisaTypesAsync(BeanzCommonDTO common)
            => _repository.GetVisaTypesAsync(common);

        public Task<BeanzResponseDTO> SetVisaTypesAsync(BeanzCommonDTO common)
            => _repository.SetVisaTypesAsync(common);

        public Task<BeanzResponseDTO> PostVisaTypesAsync(BeanzCommonDTO common)
            => _repository.PostVisaTypesAsync(common);

        public Task<BeanzResponseDTO> DelVisaTypesAsync(BeanzCommonDTO common)
            => _repository.DelVisaTypesAsync(common);

        public Task<VisaTypeViewModel> GetInfoVisaTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoVisaTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveVisaTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveVisaTypesAsync(common);
    }
}
