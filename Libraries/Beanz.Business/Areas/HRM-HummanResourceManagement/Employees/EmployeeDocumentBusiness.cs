using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Employees
{
    public class EmployeeDocumentBusiness
    {
        private readonly IEmployeeDocumentRepository _repository;

        public EmployeeDocumentBusiness(IEmployeeDocumentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EmployeeDocumentDTO>> GetEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.GetEmployeeDocumentsAsync(common);

        public Task<BeanzResponseDTO> SetEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.SetEmployeeDocumentsAsync(common);

        public Task<BeanzResponseDTO> PostEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.PostEmployeeDocumentsAsync(common);

        public Task<BeanzResponseDTO> DelEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.DelEmployeeDocumentsAsync(common);

        public Task<EmployeeDocumentViewModel> GetInfoEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.GetInfoEmployeeDocumentsAsync(common);

        public Task<BeanzResponseDTO> ApproveEmployeeDocumentsAsync(BeanzCommonDTO common)
            => _repository.ApproveEmployeeDocumentsAsync(common);
    }
}
