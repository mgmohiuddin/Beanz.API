using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Policies
{
    public class EndOfServicePolicySalaryAllowanceBusiness
    {
        private readonly IEndOfServicePolicySalaryAllowanceRepository _repository;

        public EndOfServicePolicySalaryAllowanceBusiness(IEndOfServicePolicySalaryAllowanceRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EndOfServicePolicySalaryAllowanceDTO>> GetEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetEndOfServicePolicySalaryAllowancesAsync(common);

        public Task<BeanzResponseDTO> SetEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.SetEndOfServicePolicySalaryAllowancesAsync(common);

        public Task<BeanzResponseDTO> PostEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.PostEndOfServicePolicySalaryAllowancesAsync(common);

        public Task<BeanzResponseDTO> DelEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.DelEndOfServicePolicySalaryAllowancesAsync(common);

        public Task<EndOfServicePolicySalaryAllowanceViewModel> GetInfoEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.GetInfoEndOfServicePolicySalaryAllowancesAsync(common);

        public Task<BeanzResponseDTO> ApproveEndOfServicePolicySalaryAllowancesAsync(BeanzCommonDTO common)
            => _repository.ApproveEndOfServicePolicySalaryAllowancesAsync(common);
    }
}
