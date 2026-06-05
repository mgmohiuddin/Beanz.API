using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.Common;
using Beanz.DTOs.Areas.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class BonusTypeBusiness
    {
        private readonly IBonusTypeRepository _repository;

        public BonusTypeBusiness(IBonusTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<BonusTypeDTO>> GetBonusTypesAsync(BeanzCommonDTO common)
            => _repository.GetBonusTypesAsync(common);

        public Task<BeanzResponseDTO> SetBonusTypesAsync(BeanzCommonDTO common)
            => _repository.SetBonusTypesAsync(common);

        public Task<BeanzResponseDTO> PostBonusTypesAsync(BeanzCommonDTO common)
            => _repository.PostBonusTypesAsync(common);

        public Task<BeanzResponseDTO> DelBonusTypesAsync(BeanzCommonDTO common)
            => _repository.DelBonusTypesAsync(common);

        public Task<BonusTypeViewModel> GetInfoBonusTypesAsync(BeanzCommonDTO common)
            => _repository.GetInfoBonusTypesAsync(common);

        public Task<BeanzResponseDTO> ApproveBonusTypesAsync(BeanzCommonDTO common)
            => _repository.ApproveBonusTypesAsync(common);
    }
}
