using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters; 
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AllowanceTypeBusiness
    {
        private readonly IAllowanceTypeRepository _repository;

        public AllowanceTypeBusiness(IAllowanceTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowanceTypeDTO>> GetAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.GetAllowanceTypesAsync(common);

        public Task<BeanzResponseDTO> SetAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.SetAllowanceTypesAsync(common);

        public Task<BeanzResponseDTO> PostAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.PostAllowanceTypesAsync(common);

        public Task<BeanzResponseDTO> DelAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.DelAllowanceTypesAsync(common);

        public Task<AllowanceTypeViewModel> GetInfoAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowanceTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowanceTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowanceTypesAsync(common);
    }
}
