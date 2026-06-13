using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeOfficialInformationRepository
    {
        Task<List<EmployeeOfficialInformationDTO>> GetEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeOfficialInformationsAsync(BeanzCommonDTO lookup);
        Task<EmployeeOfficialInformationViewModel> GetInfoEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<EmployeeOfficialInformationViewModel> PrintEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeOfficialInformationsAsync(BeanzCommonDTO common);
    }
}
