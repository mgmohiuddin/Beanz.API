using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class SponsorBusiness
    {
        private readonly ISponsorRepository _repository;

        public SponsorBusiness(ISponsorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SponsorDTO>> GetSponsorsAsync(BeanzCommonDTO common)
            => _repository.GetSponsorsAsync(common);

        public Task<BeanzResponseDTO> SetSponsorsAsync(BeanzCommonDTO common)
            => _repository.SetSponsorsAsync(common);

        public Task<BeanzResponseDTO> PostSponsorsAsync(BeanzCommonDTO common)
            => _repository.PostSponsorsAsync(common);

        public Task<BeanzResponseDTO> DelSponsorsAsync(BeanzCommonDTO common)
            => _repository.DelSponsorsAsync(common);

        public Task<SponsorViewModel> GetInfoSponsorsAsync(BeanzCommonDTO common)
            => _repository.GetInfoSponsorsAsync(common);

        public Task<BeanzResponseDTO> ApproveSponsorsAsync(BeanzCommonDTO common)
            => _repository.ApproveSponsorsAsync(common);
    }
}
