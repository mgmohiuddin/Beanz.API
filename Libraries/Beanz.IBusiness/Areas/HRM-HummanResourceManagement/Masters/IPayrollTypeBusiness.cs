using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IPayrollTypeBusiness
    {
        Task<List<PayrollTypeDTO>> GetPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelPayrollTypesAsync(BeanzCommonDTO common);
        Task<PayrollTypeViewModel> GetInfoPayrollTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpPayrollTypesAsync(BeanzCommonDTO lookup);
        Task<PayrollTypeViewModel> PrintPayrollTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApprovePayrollTypesAsync(BeanzCommonDTO common);
    }
}
