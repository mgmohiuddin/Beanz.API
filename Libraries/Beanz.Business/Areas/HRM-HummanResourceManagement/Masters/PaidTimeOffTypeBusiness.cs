using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class PaidTimeOffTypeBusiness
    {
        private readonly IPaidTimeOffTypeRepository _repository;

        public PaidTimeOffTypeBusiness(IPaidTimeOffTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PaidTimeOffTypeDTO>> GetPaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.GetPaidTimeOffTypesAsync(common);

        public Task<BeanzResponseDTO> SetPaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.SetPaidTimeOffTypesAsync(common);

        public Task<BeanzResponseDTO> PostPaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.PostPaidTimeOffTypesAsync(common);

        public Task<BeanzResponseDTO> DelPaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.DelPaidTimeOffTypesAsync(common);

        public Task<PaidTimeOffTypeViewModel> GetInfoPaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoPaidTimeOffTypesAsync(common);

        public Task<BeanzResponseDTO> ApprovePaidTimeOffTypesAsync(BeanzCommonDTO common)
            => _repository.ApprovePaidTimeOffTypesAsync(common);
    }
}
