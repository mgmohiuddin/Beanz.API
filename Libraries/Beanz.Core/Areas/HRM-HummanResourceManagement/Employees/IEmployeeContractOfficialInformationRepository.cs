using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeContractOfficialInformationRepository
    {
        Task<List<EmployeeContractOfficialInformationDTO>> GetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeContractOfficialInformationsAsync(BeanzCommonDTO lookup);
        Task<EmployeeContractOfficialInformationViewModel> GetInfoEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<EmployeeContractOfficialInformationViewModel> PrintEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeContractOfficialInformationsAsync(BeanzCommonDTO common);
    }
}
