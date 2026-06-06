using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Policies
{
    public interface IInsurancePolicieRepository
    {
        Task<List<InsurancePolicieDTO>> GetInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpInsurancePoliciesAsync(BeanzCommonDTO lookup);
        Task<InsurancePolicieViewModel> GetInfoInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<InsurancePolicieViewModel> PrintInsurancePoliciesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveInsurancePoliciesAsync(BeanzCommonDTO common);
    }
}
