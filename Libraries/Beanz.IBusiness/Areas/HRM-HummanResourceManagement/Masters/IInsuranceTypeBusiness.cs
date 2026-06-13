using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IInsuranceTypeBusiness
    {
        Task<List<InsuranceTypeDTO>> GetInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelInsuranceTypesAsync(BeanzCommonDTO common);
        Task<InsuranceTypeViewModel> GetInfoInsuranceTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpInsuranceTypesAsync(BeanzCommonDTO lookup);
        Task<InsuranceTypeViewModel> PrintInsuranceTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveInsuranceTypesAsync(BeanzCommonDTO common);
    }
}
