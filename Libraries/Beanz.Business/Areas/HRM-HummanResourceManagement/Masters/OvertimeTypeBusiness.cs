using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class OvertimeTypeBusiness
    {
        private readonly IOvertimeTypeRepository _repository;

        public OvertimeTypeBusiness(IOvertimeTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<OvertimeTypeDTO>> GetOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.GetOvertimeTypesAsync(common);

        public Task<BeanzResponseDTO> SetOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.SetOvertimeTypesAsync(common);

        public Task<BeanzResponseDTO> PostOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.PostOvertimeTypesAsync(common);

        public Task<BeanzResponseDTO> DelOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.DelOvertimeTypesAsync(common);

        public Task<OvertimeTypeViewModel> GetInfoOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoOvertimeTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveOvertimeTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveOvertimeTypesAsync(common);
    }
}
