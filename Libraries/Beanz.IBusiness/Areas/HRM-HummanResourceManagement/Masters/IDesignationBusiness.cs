using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IDesignationBusiness
    {
        Task<List<DesignationDTO>> GetDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelDesignationsAsync(BeanzCommonDTO common);
        Task<DesignationViewModel> GetInfoDesignationsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpDesignationsAsync(BeanzCommonDTO lookup);
        Task<DesignationViewModel> PrintDesignationsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveDesignationsAsync(BeanzCommonDTO common);
    }
}
