using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.HummanResourceManagement.Masters
{
    public interface ILoanTypeRepository
    {
        Task<List<LoanTypeDTO>> GetLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLoanTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLoanTypesAsync(BeanzCommonDTO lookup);
        Task<LoanTypeViewModel> GetInfoLoanTypesAsync(BeanzCommonDTO common);
        Task<LoanTypeViewModel> PrintLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLoanTypesAsync(BeanzCommonDTO common);
    }
}
