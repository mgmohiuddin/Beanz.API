using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class LoanTypeBusiness
    {
        private readonly ILoanTypeRepository _repository;

        public LoanTypeBusiness(ILoanTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LoanTypeDTO>> GetLoanTypesAsync(BeanzCommonDTO common)
            => _repository.GetLoanTypesAsync(common);

        public Task<BeanzResponseDTO> SetLoanTypesAsync(BeanzCommonDTO common)
            => _repository.SetLoanTypesAsync(common);

        public Task<BeanzResponseDTO> PostLoanTypesAsync(BeanzCommonDTO common)
            => _repository.PostLoanTypesAsync(common);

        public Task<BeanzResponseDTO> DelLoanTypesAsync(BeanzCommonDTO common)
            => _repository.DelLoanTypesAsync(common);

        public Task<LoanTypeViewModel> GetInfoLoanTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoLoanTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveLoanTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveLoanTypesAsync(common);
    }
}
