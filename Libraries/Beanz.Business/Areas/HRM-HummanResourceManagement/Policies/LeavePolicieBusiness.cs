using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class LeavePolicieBusiness
    {
        private readonly ILeavePolicieRepository _repository;

        public LeavePolicieBusiness(ILeavePolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeavePolicieDTO>> GetLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetLeavePoliciesAsync(common);

        public Task<BeanzResponseDTO> SetLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.SetLeavePoliciesAsync(common);

        public Task<BeanzResponseDTO> PostLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.PostLeavePoliciesAsync(common);

        public Task<BeanzResponseDTO> DelLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.DelLeavePoliciesAsync(common);

        public Task<LeavePolicieViewModel> GetInfoLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLeavePoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveLeavePoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveLeavePoliciesAsync(common);
    }
}
