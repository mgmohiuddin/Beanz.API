using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AllowancesGroupBusiness
    {
        private readonly IAllowancesGroupRepository _repository;

        public AllowancesGroupBusiness(IAllowancesGroupRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowancesGroupDTO>> GetAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.GetAllowancesGroupsAsync(common);

        public Task<BeanzResponseDTO> SetAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.SetAllowancesGroupsAsync(common);

        public Task<BeanzResponseDTO> PostAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.PostAllowancesGroupsAsync(common);

        public Task<BeanzResponseDTO> DelAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.DelAllowancesGroupsAsync(common);

        public Task<AllowancesGroupViewModel> GetInfoAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancesGroupsAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancesGroupsAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancesGroupsAsync(common);
    }
}
