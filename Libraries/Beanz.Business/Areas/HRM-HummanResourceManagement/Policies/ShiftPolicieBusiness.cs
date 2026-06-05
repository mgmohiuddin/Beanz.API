using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class ShiftPolicieBusiness
    {
        private readonly IShiftPolicieRepository _repository;

        public ShiftPolicieBusiness(IShiftPolicieRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ShiftPolicieDTO>> GetShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetShiftPoliciesAsync(common);

        public Task<BeanzResponseDTO> SetShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.SetShiftPoliciesAsync(common);

        public Task<BeanzResponseDTO> PostShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.PostShiftPoliciesAsync(common);

        public Task<BeanzResponseDTO> DelShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.DelShiftPoliciesAsync(common);

        public Task<ShiftPolicieViewModel> GetInfoShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.GetInfoShiftPoliciesAsync(common);

        public Task<BeanzResponseDTO> ApproveShiftPoliciesAsync(BeanzCommonDTO common)
            => _repository.ApproveShiftPoliciesAsync(common);
    }
}
