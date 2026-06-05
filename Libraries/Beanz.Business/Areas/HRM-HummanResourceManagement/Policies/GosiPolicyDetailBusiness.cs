using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class GosiPolicyDetailBusiness
    {
        private readonly IGosiPolicyDetailRepository _repository;

        public GosiPolicyDetailBusiness(IGosiPolicyDetailRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GosiPolicyDetailDTO>> GetGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.GetGosiPolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> SetGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.SetGosiPolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> PostGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.PostGosiPolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> DelGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.DelGosiPolicyDetailsAsync(common);

        public Task<GosiPolicyDetailViewModel> GetInfoGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.GetInfoGosiPolicyDetailsAsync(common);

        public Task<BeanzResponseDTO> ApproveGosiPolicyDetailsAsync(BeanzCommonDTO common)
            => _repository.ApproveGosiPolicyDetailsAsync(common);
    }
}
