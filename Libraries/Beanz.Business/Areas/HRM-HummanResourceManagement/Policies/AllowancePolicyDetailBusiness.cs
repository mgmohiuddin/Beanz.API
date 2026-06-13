using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HumanResourceManagement.Policies
{
    public class AllowancePolicyDetailBusiness
    {
        private readonly IAllowancePolicyDetailRepository _repository;

        public AllowancePolicyDetailBusiness(IAllowancePolicyDetailRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AllowancePolicyDetailDTO>> GetAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.GetAllowancePolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> SetAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.SetAllowancePolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> PostAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.PostAllowancePolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> DelAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.DelAllowancePolicyDetailsAsync(common);

        public Task<AllowancePolicyDetailViewModel> GetInfoAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.GetInfoAllowancePolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> ApproveAllowancePolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.ApproveAllowancePolicyDetailsAsync(common);
    }
}
