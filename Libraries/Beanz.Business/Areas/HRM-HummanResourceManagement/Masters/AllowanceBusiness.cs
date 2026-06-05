using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AllowanceBusiness
    {
        private readonly IAllowanceRepository _repository;

        public AllowanceBusiness(IAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowanceDTO>> GetAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelAllowancesAsync(common);

        public Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancesAsync(common);
    }
}
