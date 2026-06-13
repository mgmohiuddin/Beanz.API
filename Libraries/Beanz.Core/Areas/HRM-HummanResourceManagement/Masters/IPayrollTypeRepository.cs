using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface IPayrollTypeRepository
    {
        Task<List<PayrollTypeDTO>> GetPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollTypesAsync(BeanzCommonDTO lookup);
        Task<PayrollTypeViewModel> GetInfoPayrollTypesAsync(BeanzCommonDTO common);
        Task<PayrollTypeViewModel> PrintPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollTypesAsync(BeanzCommonDTO common);
    }
}
