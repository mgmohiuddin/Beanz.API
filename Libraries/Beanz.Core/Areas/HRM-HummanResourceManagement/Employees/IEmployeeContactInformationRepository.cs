using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeContactInformationRepository
    {
        Task<List<EmployeeContactInformationDTO>> GetEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeContactInformationsAsync(BeanzCommonDTO lookup);
        Task<EmployeeContactInformationViewModel> GetInfoEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<EmployeeContactInformationViewModel> PrintEmployeeContactInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeContactInformationsAsync(BeanzCommonDTO common);
    }
}
