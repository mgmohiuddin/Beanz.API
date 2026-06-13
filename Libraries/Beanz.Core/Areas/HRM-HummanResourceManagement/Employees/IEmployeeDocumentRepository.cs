using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Employees
{
    public interface IEmployeeDocumentRepository
    {
        Task<List<EmployeeDocumentDTO>> GetEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeDocumentsAsync(BeanzCommonDTO lookup);
        Task<EmployeeDocumentViewModel> GetInfoEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<EmployeeDocumentViewModel> PrintEmployeeDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeDocumentsAsync(BeanzCommonDTO common);
    }
}
