using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeFinancialInformationRepository
    {
        Task<List<EmployeeFinancialInformationDTO>> GetEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeFinancialInformationsAsync(BeanzCommonDTO lookup);
        Task<EmployeeFinancialInformationViewModel> GetInfoEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<EmployeeFinancialInformationViewModel> PrintEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeFinancialInformationsAsync(BeanzCommonDTO common);
    }
}
