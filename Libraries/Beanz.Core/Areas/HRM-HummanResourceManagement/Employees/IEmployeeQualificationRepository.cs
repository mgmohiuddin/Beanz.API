using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeQualificationRepository
    {
        Task<List<EmployeeQualificationDTO>> GetEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeQualificationsAsync(BeanzCommonDTO lookup);
        Task<EmployeeQualificationViewModel> GetInfoEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<EmployeeQualificationViewModel> PrintEmployeeQualificationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeQualificationsAsync(BeanzCommonDTO common);
    }
}
