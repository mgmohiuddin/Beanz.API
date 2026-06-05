using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class ShiftTypeBusiness
    {
        private readonly IShiftTypeRepository _repository;

        public ShiftTypeBusiness(IShiftTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ShiftTypeDTO>> GetShiftTypesAsync(BeanzCommonDTO common)
            => _repository.GetShiftTypesAsync(common);

        public Task<BeanzResponseDTO> SetShiftTypesAsync(BeanzCommonDTO common)
            => _repository.SetShiftTypesAsync(common);

        public Task<BeanzResponseDTO> PostShiftTypesAsync(BeanzCommonDTO common)
            => _repository.PostShiftTypesAsync(common);

        public Task<BeanzResponseDTO> DelShiftTypesAsync(BeanzCommonDTO common)
            => _repository.DelShiftTypesAsync(common);

        public Task<ShiftTypeViewModel> GetInfoShiftTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoShiftTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveShiftTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveShiftTypesAsync(common);
    }
}
