using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class ShiftPolicyEligibleBusiness
    {
        private readonly IShiftPolicyEligibleRepository _repository;

        public ShiftPolicyEligibleBusiness(IShiftPolicyEligibleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ShiftPolicyEligibleDTO>> GetShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetShiftPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> SetShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.SetShiftPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> PostShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.PostShiftPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> DelShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.DelShiftPolicyEligiblesAsync(common);

        public Task<ShiftPolicyEligibleViewModel> GetInfoShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.GetInfoShiftPolicyEligiblesAsync(common);

        public Task<BeanzResponseDTO> ApproveShiftPolicyEligiblesAsync(BeanzCommonDTO common)
            => _repository.ApproveShiftPolicyEligiblesAsync(common);
    }
}
