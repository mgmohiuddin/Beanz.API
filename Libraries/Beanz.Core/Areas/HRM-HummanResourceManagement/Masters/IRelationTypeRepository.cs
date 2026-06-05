using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface IRelationTypeRepository
    {
        Task<List<RelationTypeDTO>> GetRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelRelationTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpRelationTypesAsync(BeanzCommonDTO lookup);
        Task<RelationTypeViewModel> GetInfoRelationTypesAsync(BeanzCommonDTO common);
        Task<RelationTypeViewModel> PrintRelationTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveRelationTypesAsync(BeanzCommonDTO common);
    }
}
