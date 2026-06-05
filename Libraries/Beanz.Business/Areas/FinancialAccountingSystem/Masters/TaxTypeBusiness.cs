using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Masters
{
    public class TaxTypeBusiness
    {
        private readonly ITaxTypeRepository _repository;

        public TaxTypeBusiness(ITaxTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TaxTypeDTO>> GetTaxTypesAsync(BeanzCommonDTO common)
            => _repository.GetTaxTypesAsync(common);

        public Task<BeanzResponseDTO> SetTaxTypesAsync(BeanzCommonDTO common)
            => _repository.SetTaxTypesAsync(common);

        public Task<BeanzResponseDTO> PostTaxTypesAsync(BeanzCommonDTO common)
            => _repository.PostTaxTypesAsync(common);

        public Task<BeanzResponseDTO> DelTaxTypesAsync(BeanzCommonDTO common)
            => _repository.DelTaxTypesAsync(common);

        public Task<TaxTypeViewModel> GetInfoTaxTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoTaxTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveTaxTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveTaxTypesAsync(common);
    }
}
