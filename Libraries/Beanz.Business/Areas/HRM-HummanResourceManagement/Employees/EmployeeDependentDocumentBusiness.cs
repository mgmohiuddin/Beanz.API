using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeDependentDocumentBusiness
    {
        private readonly IEmployeeDependentDocumentRepository _repository;

        public EmployeeDependentDocumentBusiness(IEmployeeDependentDocumentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeDependentDocumentDTO>> GetEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeDependentDocumentsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeDependentDocumentsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeDependentDocumentsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeDependentDocumentsAsync(common);

        public Task<EmployeeDependentDocumentViewModel> GetInfoEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeDependentDocumentsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeDependentDocumentsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeDependentDocumentsAsync(common);
    }
}
