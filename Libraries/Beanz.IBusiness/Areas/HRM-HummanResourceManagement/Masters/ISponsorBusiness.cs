using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface ISponsorBusiness
    {
        Task<List<SponsorDTO>> GetSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSponsorsAsync(BeanzCommonDTO common);
        Task<SponsorViewModel> GetInfoSponsorsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSponsorsAsync(BeanzCommonDTO lookup);
        Task<SponsorViewModel> PrintSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSponsorsAsync(BeanzCommonDTO common);
    }
}
