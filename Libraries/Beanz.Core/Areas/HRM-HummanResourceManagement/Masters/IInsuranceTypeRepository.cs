using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IInsuranceTypeRepository
    {
        Task<List<InsuranceTypeDTO>> GetInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelInsuranceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpInsuranceTypesAsync(BeanzCommonDTO lookup);
        Task<InsuranceTypeViewModel> GetInfoInsuranceTypesAsync(BeanzCommonDTO common);
        Task<InsuranceTypeViewModel> PrintInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveInsuranceTypesAsync(BeanzCommonDTO common);
    }
}
