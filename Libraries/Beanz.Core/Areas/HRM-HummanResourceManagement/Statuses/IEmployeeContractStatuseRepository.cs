using Beanz.DTOs.Areas.HumanResourceManagement.Statuses;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Statuses
{
    public interface IEmployeeContractStatuseRepository
    {
        Task<List<EmployeeContractStatuseDTO>> GetEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeContractStatusesAsync(BeanzCommonDTO lookup);
        Task<EmployeeContractStatuseViewModel> GetInfoEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<EmployeeContractStatuseViewModel> PrintEmployeeContractStatusesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeContractStatusesAsync(BeanzCommonDTO common);
    }
}
