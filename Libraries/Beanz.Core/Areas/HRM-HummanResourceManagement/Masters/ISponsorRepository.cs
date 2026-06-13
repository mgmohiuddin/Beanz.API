using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HumanResourceManagement.Masters
{
    public interface ISponsorRepository
    {
        Task<List<SponsorDTO>> GetSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelSponsorsAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpSponsorsAsync(BeanzCommonDTO lookup);
        Task<SponsorViewModel> GetInfoSponsorsAsync(BeanzCommonDTO common);
        Task<SponsorViewModel> PrintSponsorsAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveSponsorsAsync(BeanzCommonDTO common);
    }
}
