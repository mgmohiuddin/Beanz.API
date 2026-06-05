using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.System.Setup;
using Beanz.DTOs.Areas.System.Setup;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.System.Setup
{
    public class SystemScreenBusiness
    {
        private readonly ISystemScreenRepository _repository;

        public SystemScreenBusiness(ISystemScreenRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SystemScreenDTO>> GetSystemScreensAsync(BeanzCommonDTO common)
            => _repository.GetSystemScreensAsync(common);

        public Task<BeanzResponseDTO> SetSystemScreensAsync(BeanzCommonDTO common)
            => _repository.SetSystemScreensAsync(common);

        public Task<BeanzResponseDTO> PostSystemScreensAsync(BeanzCommonDTO common)
            => _repository.PostSystemScreensAsync(common);

        public Task<BeanzResponseDTO> DelSystemScreensAsync(BeanzCommonDTO common)
            => _repository.DelSystemScreensAsync(common);

        public Task<SystemScreenViewModel> GetInfoSystemScreensAsync(BeanzCommonDTO common)
            => _repository.GetInfoSystemScreensAsync(common);

        public Task<BeanzResponseDTO> ApproveSystemScreensAsync(BeanzCommonDTO common)
            => _repository.ApproveSystemScreensAsync(common);
    }
}
