using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.Models.Areas.HummanResourceManagement.Masters;
using Beanz.Models.Areas.HummanResourceManagement.Masters.Objects;
using Beanz.Domain.Common;

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

        public Task<string> SetAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetAllowancesAsync(common);

        public Task<string> PostAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostAllowancesAsync(common);

        public Task<string> DelAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelAllowancesAsync(common);

        public Task<AllowanceViewModel> GetInfoAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancesAsync(common);
    }
}
