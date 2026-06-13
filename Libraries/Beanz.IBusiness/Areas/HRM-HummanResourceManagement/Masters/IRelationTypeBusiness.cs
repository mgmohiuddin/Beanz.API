using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HumanResourceManagement.Masters
{
    public interface IRelationTypeBusiness
    {
        Task<List<RelationTypeDTO>> GetRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelRelationTypesAsync(BeanzCommonDTO common);
        Task<RelationTypeViewModel> GetInfoRelationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpRelationTypesAsync(BeanzCommonDTO lookup);
        Task<RelationTypeViewModel> PrintRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveRelationTypesAsync(BeanzCommonDTO common);
    }
}
