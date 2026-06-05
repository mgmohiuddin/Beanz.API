using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.Core.Areas.System.Setup;
using Beanz.DTOs.Areas.System.Setup;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Business.Areas.System.Setup
{
    public class SystemModuleBusiness
    {
        private readonly ISystemModuleRepository _repository;

        public SystemModuleBusiness(ISystemModuleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SystemModuleDTO>> GetSystemModulesAsync(BeanzCommonDTO common)
            => _repository.GetSystemModulesAsync(common);

        public Task<BeanzResponseDTO> SetSystemModulesAsync(BeanzCommonDTO common)
            => _repository.SetSystemModulesAsync(common);

        public Task<BeanzResponseDTO> PostSystemModulesAsync(BeanzCommonDTO common)
            => _repository.PostSystemModulesAsync(common);

        public Task<BeanzResponseDTO> DelSystemModulesAsync(BeanzCommonDTO common)
            => _repository.DelSystemModulesAsync(common);

        public Task<SystemModuleViewModel> GetInfoSystemModulesAsync(BeanzCommonDTO common)
            => _repository.GetInfoSystemModulesAsync(common);

        public Task<BeanzResponseDTO> ApproveSystemModulesAsync(BeanzCommonDTO common)
            => _repository.ApproveSystemModulesAsync(common);
    }
}
