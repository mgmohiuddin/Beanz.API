using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeContractRepository
    {
        Task<List<EmployeeContractDTO>> GetEmployeeContractsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeContractsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeContractsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeContractsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeContractsAsync(BeanzCommonDTO lookup);
        Task<EmployeeContractViewModel> GetInfoEmployeeContractsAsync(BeanzCommonDTO common);
        Task<EmployeeContractViewModel> PrintEmployeeContractsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeContractsAsync(BeanzCommonDTO common);
    }
}
