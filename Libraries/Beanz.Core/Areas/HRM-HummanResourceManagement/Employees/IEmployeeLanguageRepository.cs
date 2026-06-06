using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeLanguageRepository
    {
        Task<List<EmployeeLanguageDTO>> GetEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeLanguagesAsync(BeanzCommonDTO lookup);
        Task<EmployeeLanguageViewModel> GetInfoEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<EmployeeLanguageViewModel> PrintEmployeeLanguagesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeLanguagesAsync(BeanzCommonDTO common);
    }
}
