using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IDesignationRepository
    {
        Task<List<DesignationDTO>> GetDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDesignationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDesignationsAsync(BeanzCommonDTO lookup);
        Task<DesignationViewModel> GetInfoDesignationsAsync(BeanzCommonDTO common);
        Task<DesignationViewModel> PrintDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDesignationsAsync(BeanzCommonDTO common);
    }
}
