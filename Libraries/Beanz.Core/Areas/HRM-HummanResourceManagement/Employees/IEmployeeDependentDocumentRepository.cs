using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Employees
{
    public interface IEmployeeDependentDocumentRepository
    {
        Task<List<EmployeeDependentDocumentDTO>> GetEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpEmployeeDependentDocumentsAsync(BeanzCommonDTO lookup);
        Task<EmployeeDependentDocumentViewModel> GetInfoEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<EmployeeDependentDocumentViewModel> PrintEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveEmployeeDependentDocumentsAsync(BeanzCommonDTO common);
    }
}
